using System.Data;
using System.Globalization;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.ViewModels;
using RP.Library.Helpers.Service;
using Microsoft.AspNetCore.Http;
using Serilog;
using Color = DocumentFormat.OpenXml.Spreadsheet.Color;

namespace RP.Affiliate.Tracking.Functions.Implementation
{
    public class ImportAffiliateProductFunctions(
        IAffiliateProductRepository affiliateProductRepository,
        AffiliateContext affiliateContext,
        IBaseService baseService) : IImportAffiliateProductFunctions
    {
        private const int START_ROW_INDEX = 3;
        private const int MAX_LENGTH_REF_PRODUCT = 50;
        private const int MAX_LENGTH_PRODUCT_NAME = 255;
        private const decimal MAX_PRICE = 8999999999999999M;
        private const string RED_COLOR_HEX = "FF0000";
        private const int INDEX_COL_ERR = 8;
        private const string COL_NAME_ERROR = "Error";
        private const int INDEX_ROW_ERROR = 2;

        private readonly IAffiliateProductRepository _affiliateProductRepository = affiliateProductRepository;
        private readonly AffiliateContext _context = affiliateContext;
        private readonly IBaseService _baseService = baseService;

        public async Task<ImportAffiliateProductResult> ImportAffiliateProduct(ImportAffiliateProductCommand request)
        {
            // init params
            ImportAffiliateProductResult affiliateProductResult = new ImportAffiliateProductResult();

            try
            {
                if(_baseService.isInvalidAffiliateStore(request.AffiliateStoreId, request.StoreId))
                {
                    throw new Exception("Affiliate store id not found!");
                }

                var dt = await ReadDataFromExcelToDataTable(request.File);
                var buildedAffProductList = BuildAffProductList(dt, request.AffiliateStoreId, request.LangKey);
                affiliateProductResult.TotalCount = dt.Rows.Count;
                affiliateProductResult.SuccessCount = buildedAffProductList.SucceededAffiliateProducts.Count;
                affiliateProductResult.ErrorCount = buildedAffProductList.IndexRowsFailed.Count;
                affiliateProductResult.HasError = affiliateProductResult.ErrorCount > 0 ? true : false;
                affiliateProductResult.ErrorData = affiliateProductResult.ErrorData;

                //Import to Database in here
                if (affiliateProductResult.SuccessCount > 0)
                {
                    var importedAffiliateProducts = buildedAffProductList.SucceededAffiliateProducts
                        .GroupBy(x => x.RefProductId)
                        .Select(group => group.Last())
                        .ToList();
                    await _affiliateProductRepository.InsertOrUpdateByBulkAsync(importedAffiliateProducts, request.AffiliateStoreId);
                }

                if (affiliateProductResult.HasError)
                {
                    affiliateProductResult.ErrorData = await ExportErrorDataToExcel(buildedAffProductList.IndexRowsSucceeded, buildedAffProductList.ErrorData, request.File);
                }

                Log.Logger.Information($"DONE {nameof(ImportAffiliateProductFunctions)}");

                return affiliateProductResult;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(ImportAffiliateProductFunctions)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private async static Task<DataTable> ReadDataFromExcelToDataTable(IFormFile uploadedFile)
        {
            using (var ms = new MemoryStream())
            {
                await uploadedFile.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);

                DataTable dt = new DataTable();
                int startRow = START_ROW_INDEX;
                var headerColumnExcelTemplateVN = new List<string>() 
                {
                    "Mã sản phẩm liên kết",
                    "Tên sản phẩm",
                    "Mã danh mục",
                    "Giá gốc",
                    "Giá khuyến mãi",
                    "Đường dẫn sản phẩm",
                    "Đường dẫn hình ảnh",
                };
                var headerColumnExcelTemplateEN = new List<string>()
                {
                    "Ref Product ID",
                    "Product Name",
                    "Category ID",
                    "Price",
                    "Sale Price",
                    "Product Link",
                    "Image Url",
                };

                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(ms, false))
                {
                    //Read the first Sheets 
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(1))
                    {
                        dt.Columns.Add(GetCellValue(doc, cell));
                    }
                    foreach (Row row in rows)
                    {
                        if (row.RowIndex.Value < startRow - 1)
                        {
                            continue;
                        }
                        else if (row.RowIndex.Value == startRow - 1) 
                        {
                            DataRow dtRow = dt.NewRow();

                            // Iterate over all columns in the row
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                // Get the column index of the cell
                                string columnName = GetColumnName(cell.CellReference);
                                int columnIndex = GetColumnIndexFromName(columnName);

                                // If the cell has data, add it to the DataTable
                                if (cell.CellValue != null)
                                {
                                    dtRow[columnIndex] = GetCellValue(doc, cell);
                                }
                                else
                                {
                                    // If the cell is empty, you can assign null or any default value
                                    dtRow[columnIndex] = null; // or any default value you want
                                }
                            }
                            //check template excel
                            var headerColumnExcelImport = dtRow.ItemArray.ToList();
                            if(!(headerColumnExcelTemplateVN.SequenceEqual(headerColumnExcelImport) || headerColumnExcelTemplateEN.SequenceEqual(headerColumnExcelImport)))
                            {
                                throw new Exception("The import file is not a supported template. Please check and try again.");
                            }
                        }
                        else
                        {
                            DataRow dtRow = dt.NewRow();

                            // Iterate over all columns in the row
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                // Get the column index of the cell
                                string columnName = GetColumnName(cell.CellReference);
                                int columnIndex = GetColumnIndexFromName(columnName);

                                // If the cell has data, add it to the DataTable
                                if (cell.CellValue != null)
                                {
                                    dtRow[columnIndex] = GetCellValue(doc, cell);
                                }
                                else
                                {
                                    // If the cell is empty, you can assign null or any default value
                                    dtRow[columnIndex] = null; // or any default value you want
                                }
                            }
                            dt.Rows.Add(dtRow);
                        }
                    }

                }
                return dt;
            }
        }

        private async static Task<byte[]> ExportErrorDataToExcel(List<int> rowsToDelete, Dictionary<int, string> errorData, IFormFile uploadedFile)
        {
            using (var ms = new MemoryStream())
            {
                await uploadedFile.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);

                // Open the Excel file
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(ms, true))
                {
                    // Access the workbook
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                    // Access the sheet data
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    DrawColumnName(sheetData);

                    WriteErrorMessage(workbookPart, sheetData, errorData);

                    // Create a list to store the indices of rows to be deleted and delete the rows
                    List<int> sortedRowsToDelete = rowsToDelete.OrderByDescending(x => x).ToList();
                    foreach (int rowToDelete in sortedRowsToDelete)
                    {
                        Row row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowToDelete);
                        if (row != null)
                        {
                            sheetData.RemoveChild(row);
                        }
                        else
                        {
                            Log.Logger.Information($"Không tìm thấy hàng {rowToDelete}.");
                        }
                    }

                    // Adjust the indices of the remaining rows
                    foreach (Row row in sheetData.Elements<Row>())
                    {
                        uint rowIndex = row.RowIndex;
                        if (sortedRowsToDelete.Any(x => x < rowIndex))
                        {
                            row.RowIndex = rowIndex - (uint)sortedRowsToDelete.Count(x => x < rowIndex);
                            foreach (Cell cell in row.Elements<Cell>())
                            {
                                string reference = cell.CellReference?.Value;
                                if (reference != null)
                                {
                                    cell.CellReference = new StringValue(reference.Replace(rowIndex.ToString(), row.RowIndex.ToString()));
                                }
                            }
                        }
                    }

                    worksheetPart.Worksheet.Save();
                }

                byte[] updatedFileBytes = ms.ToArray();
                return updatedFileBytes;
            }
        }

        private BuildedAffiliateProductResult BuildAffProductList(DataTable dt, long affiliateStoreId, string langKey = "en")
        {
            try
            {
                var buildedAffiliateProductViewModel = new BuildedAffiliateProductResult();
                int startRow = START_ROW_INDEX;
                var categoryList = _context.AffiliateCategory
                    .Where(x => x.AffiliateStoreId == affiliateStoreId)
                    .Select(x => new
                    {
                        Key = x.RefCategoryId,
                        Value = x.Id,
                    })
                    .ToDictionary(y => y.Key, y => y.Value);

                foreach (DataRow row in dt.Rows)
                {
                    if (!row.ItemArray.Any(x => x != DBNull.Value))
                    {
                        //check value of all column items is empty
                        continue;
                    }
                    var affProduct = new AffiliateProduct();
                    affProduct.AffiliateStoreId = affiliateStoreId;
                    bool isValidDataRow = true;
                    var listErrors = new List<string>();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string errMessage = BuildErrorMessage(row, categoryList, i, dt.Columns[i].ColumnName, langKey);
                        if (!string.IsNullOrEmpty(errMessage))
                        {
                            isValidDataRow = false;
                            listErrors.Add(errMessage);
                        }
                        else
                        {
                            if (isValidDataRow)
                            {
                                BuildAffProductFromDataRow(row, categoryList, i, ref affProduct);
                            }
                        }
                    }

                    if (listErrors.Count > 0)
                    {
                        buildedAffiliateProductViewModel.ErrorData.Add(dt.Rows.IndexOf(row) + startRow, string.Join(",\n", listErrors));
                        buildedAffiliateProductViewModel.IndexRowsFailed.Add(dt.Rows.IndexOf(row) + startRow);
                    }
                    else
                    {
                        buildedAffiliateProductViewModel.SucceededAffiliateProducts.Add(affProduct);
                        buildedAffiliateProductViewModel.IndexRowsSucceeded.Add(dt.Rows.IndexOf(row) + startRow);
                    }
                }

                return buildedAffiliateProductViewModel;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(BuildAffProductList)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private void BuildAffProductFromDataRow(DataRow dataRow, Dictionary<string, long> categoryList, int colIndex, ref AffiliateProduct affProduct)
        {
            var dataColStr = dataRow[colIndex]?.ToString() ?? "";

            if (colIndex == AffiliateProductColumns.REF_PRODUCT_ID)
            {
                if (dataColStr.Length > MAX_LENGTH_REF_PRODUCT)
                {
                    affProduct.RefProductId = dataColStr.Substring(0, MAX_LENGTH_REF_PRODUCT);
                }
                else
                {
                    affProduct.RefProductId = dataColStr;
                }
            }
            if (colIndex == AffiliateProductColumns.PRODUCT_NAME)
            {
                if (dataColStr.Length > MAX_LENGTH_PRODUCT_NAME)
                {
                    affProduct.Name = dataColStr.Substring(0, MAX_LENGTH_PRODUCT_NAME);
                }
                else
                {
                    affProduct.Name = dataColStr;
                }
            }
            if (colIndex == AffiliateProductColumns.CATEGORY_ID)
            {
                if (!string.IsNullOrEmpty(dataColStr))
                {
                    categoryList.TryGetValue(dataColStr, out var categoryId);
                    affProduct.CategoryId = categoryId;
                }
            }
            if (colIndex == AffiliateProductColumns.PRICE)
            {
                if (decimal.TryParse(dataColStr, CultureInfo.InvariantCulture, out decimal price))
                {
                    if (price < 0)
                    {
                        affProduct.RegularPrice = 0;
                    }
                    else if (price > MAX_PRICE)
                    {
                        affProduct.RegularPrice = MAX_PRICE;
                    }
                    else
                    {
                        affProduct.RegularPrice = price;
                    }
                }
                else
                {
                    affProduct.RegularPrice = 0;
                }
            }
            if (colIndex == AffiliateProductColumns.SALE_PRICE)
            {
                if (decimal.TryParse(dataColStr, CultureInfo.InvariantCulture, out decimal salePrice))
                {
                    if (salePrice < 0)
                    {
                        affProduct.SalePrice = 0;
                    }
                    else if (salePrice > affProduct.RegularPrice)
                    {
                        affProduct.SalePrice = affProduct.RegularPrice;
                    }
                    else
                    {
                        affProduct.SalePrice = salePrice;
                    }
                }
                else
                {
                    affProduct.SalePrice = 0;
                }
            }
            if (colIndex == AffiliateProductColumns.PRODUCT_LINK)
            {
                affProduct.ProductUrl = dataColStr;
            }
            if (colIndex == AffiliateProductColumns.URL_IMAGE)
            {
                affProduct.ImageUrl = dataColStr;
            }
        }

        private static string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue?.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
            }
            return value;
        }

        private string BuildErrorMessage(DataRow dataRow, Dictionary<string, long> categoryList, int colIndex, string columnName, string langKey = "en")
        {
            var dataColStr = dataRow[colIndex]?.ToString() ?? "";

            if (colIndex == AffiliateProductColumns.REF_PRODUCT_ID)
            {
                if (IsCellNullOrEmpty(dataColStr))
                {
                    return columnName + (langKey == "en" ? " is required. Please do not leave it blank" : " là giá trị bắt buộc. Vui lòng không để trống");
                }
            }
            else if (colIndex == AffiliateProductColumns.PRODUCT_NAME)
            {
                if (IsCellNullOrEmpty(dataColStr))
                {
                    return columnName + (langKey == "en" ? " is required. Please do not leave it blank" : " là giá trị bắt buộc. Vui lòng không để trống");
                }
            }
            else if (colIndex == AffiliateProductColumns.CATEGORY_ID)
            {
                if (!string.IsNullOrEmpty(dataColStr))
                {
                    categoryList.TryGetValue(dataColStr, out var categoryId);
                    if (categoryId <= 0)
                    {
                        return langKey == "en" ? "Category is not existed" : "Danh mục không tồn tại";
                    }
                }
            }
            else if (colIndex == AffiliateProductColumns.PRICE)
            {
                if (IsCellNullOrEmpty(dataColStr))
                {
                    return columnName + (langKey == "en" ? " is required. This is a numeric data field. Please do not leave it blank and enter a valid value" 
                        : " là giá trị bắt buộc. Đây là trường dữ liệu số. Vui lòng không để trống và nhập giá trị hợp lệ");
                }
                else
                {
                    if (!decimal.TryParse(dataColStr, CultureInfo.InvariantCulture, out decimal result))
                    {
                        return columnName + (langKey == "en" ? " value is invalid" : " có giá trị không hợp lệ");
                    }
                }
            }
            else if (colIndex == AffiliateProductColumns.SALE_PRICE && !IsCellNullOrEmpty(dataColStr))
            {
                if (!decimal.TryParse(dataColStr, CultureInfo.InvariantCulture, out decimal result))
                {
                    return columnName + (langKey == "en" ? " value is invalid" : " có giá trị không hợp lệ");
                }
            }
        
            else if (colIndex == AffiliateProductColumns.PRODUCT_LINK)
            {
                if (IsCellNullOrEmpty(dataColStr) || !IsValidUrl(dataColStr))
                {
                    return columnName + (langKey == "en" ? "  is required. Please do not leave blank and enter a valid domain name" 
                        : " là giá trị bắt buộc. Vui lòng không để trống và nhập tên miền hợp lệ");
                }
            }

            return "";
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private bool IsCellNullOrEmpty(string dataColStr)
        {
            if (dataColStr != null && !string.IsNullOrEmpty(dataColStr) && !string.IsNullOrWhiteSpace(dataColStr))
            {
                return false;
            }

            return true;
        }

        private static void WriteErrorMessage(WorkbookPart workbookPart, SheetData sheetData, Dictionary<int, string> errorData)
        {
            foreach (var err in errorData)
            {
                string cellReference = GetCellReference(INDEX_COL_ERR, (uint)err.Key);
                Cell cellFormat = InsertOrUpdateCellInWorksheet(cellReference, sheetData);

                cellFormat.CellValue = new CellValue(err.Value);
                cellFormat.DataType = new EnumValue<CellValues>(CellValues.String);

                // Add style red color
                uint redFontId = InsertFont(workbookPart, RED_COLOR_HEX);
                cellFormat.StyleIndex = InsertCellFormat(workbookPart, redFontId);
            }
        }

        private static void DrawColumnName(SheetData sheetData)
        {
            string cellReference = GetCellReference(INDEX_COL_ERR, INDEX_ROW_ERROR);
            Cell cellFormat = InsertOrUpdateCellInWorksheet(cellReference, sheetData);

            cellFormat.CellValue = new CellValue(COL_NAME_ERROR);
            cellFormat.DataType = new EnumValue<CellValues>(CellValues.String);
        }

        private static Cell InsertOrUpdateCellInWorksheet(string cellReference, SheetData sheetData)
        {
            Cell cell = null;

            string columnName = GetColumnName(cellReference);
            uint rowIndex = GetRowIndex(cellReference);

            Row row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);
            if (row == null)
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // Check if the cell already exists in the row
            Cell existingCell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference == cellReference);
            if (existingCell != null)
            {
                cell = existingCell;
            }
            else
            {
                // If the cell doesn't exist, find the appropriate place to insert it
                Cell refCell = row.Elements<Cell>().FirstOrDefault(c => string.Compare(c.CellReference.Value, columnName + rowIndex, true) > 0);
                cell = new Cell() { CellReference = columnName + rowIndex };
                row.InsertBefore(cell, refCell);
            }

            return cell;
        }

        // Function to retrieve the row index from a cell reference string                             
        private static uint GetRowIndex(string cellReference)
        {
            string rowIndex = string.Empty;
            foreach (char ch in cellReference)
            {
                if (Char.IsDigit(ch))
                    rowIndex += ch;
            }
            return uint.Parse(rowIndex);
        }

        // Function to retrieve the column name from a cell reference string
        private static string GetColumnName(string cellReference)
        {
            string columnName = string.Empty;
            foreach (char ch in cellReference)
            {
                if (!Char.IsDigit(ch))
                    columnName += ch;
                else
                    break;
            }
            return columnName;
        }

        // Function to retrieve the cell reference string from row index and column name
        private static string GetCellReference(uint columnIndex, uint rowIndex)
        {
            return GetColumnName(columnIndex) + rowIndex;
        }

        // Function to retrieve the column name from column index   
        private static string GetColumnName(uint columnIndex)
        {
            int dividend = (int)columnIndex;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        // Utility method to get column index from column name (A = 0, B = 1, ...)
        private static int GetColumnIndexFromName(string columnName)
        {
            int columnIndex = 0;
            int factor = 1;
            for (int pos = columnName.Length - 1; pos >= 0; pos--)
            {
                columnIndex += (columnName[pos] - 'A' + 1) * factor;
                factor *= 26;
            }
            return columnIndex - 1;
        }

        // Function to insert cellFormat into the stylesheet
        private static uint InsertCellFormat(WorkbookPart workbookPart, uint fontId)
        {
            var stylesheet = workbookPart.WorkbookStylesPart.Stylesheet;

            var cellFormats = stylesheet.Elements<CellFormats>().FirstOrDefault();
            if (cellFormats == null)
            {
                cellFormats = new CellFormats();
                stylesheet.InsertAt(cellFormats, 0);
            }

            var cellFormat = new CellFormat() { FontId = fontId };
            cellFormats.AppendChild(cellFormat);

            return (uint)cellFormats.ChildElements.Count - 1;
        }

        private static uint InsertFont(WorkbookPart workbookPart, string fontColor)
        {
            var stylesheet = workbookPart.WorkbookStylesPart.Stylesheet;

            var fonts = stylesheet.Elements<DocumentFormat.OpenXml.Spreadsheet.Fonts>().FirstOrDefault();
            if (fonts == null)
            {
                fonts = new DocumentFormat.OpenXml.Spreadsheet.Fonts();
                stylesheet.InsertAt(fonts, 0);
            }

            var font = new DocumentFormat.OpenXml.Spreadsheet.Font();
            var color = new Color() { Rgb = new HexBinaryValue(fontColor) };
            font.AppendChild(color);
            fonts.AppendChild(font);

            return (uint)fonts.ChildElements.Count - 1;
        }
    }
}
