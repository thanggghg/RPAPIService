using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace RP.Library.Helpers.Excel
{
    public static class ExcelHelper
    {
        public static string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue?.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
            }
            return value;
        }

        public static string GetColumnName(string cellReference)
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
        public static int GetColumnIndexFromName(string columnName)
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

        public async static Task<DataTable> ReadDataFromExcelToDataTable(IFormFile uploadedFile, int startRow, int endColumn, int startRowHeader)
        {
            using (var ms = new MemoryStream())
            {
                await uploadedFile.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);

                DataTable dt = new DataTable();
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(ms, false))
                {
                    //Read the first Sheets 
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(startRowHeader))
                    {
                        dt.Columns.Add(ExcelHelper.GetCellValue(doc, cell));
                    }
                    foreach (Row row in rows)
                    {
                        if (row.RowIndex == null)
                        {
                            continue;
                        }
                        if (row.RowIndex != null && row.RowIndex.Value < startRow)
                        {
                            continue;
                        }
                        else
                        {
                            DataRow dtRow = dt.NewRow();

                            // Iterate over all columns in the row
                            foreach (Cell cell in row.Descendants<Cell>())
                            {
                                // Get the column index of the cell
                                string columnName = ExcelHelper.GetColumnName(cell.CellReference);
                                int columnIndex = ExcelHelper.GetColumnIndexFromName(columnName);

                                // If the cell has data, add it to the DataTable
                                if (cell.CellValue != null)
                                {
                                    dtRow[columnIndex] = ExcelHelper.GetCellValue(doc, cell);
                                }
                                else
                                {
                                    // If the cell is empty, you can assign null or any default value
                                    dtRow[columnIndex] = null; // or any default value you want
                                }

                                // If columnIndex exceeds the specified number of columns then break
                                if (columnIndex >= endColumn - 1)
                                    break;
                            }
                            dt.Rows.Add(dtRow);
                        }
                    }

                }
                return dt;
            }
        }

        public async static Task<byte[]> ExportErrorDataToExcel(List<int> rowsToDelete, Dictionary<int, string> errorData, IFormFile uploadedFile, string nameColError, uint startColError, uint startRowError, string colHex)
        {
            int startRow = 4;

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
                    var rows = GetAllRowsIncludingEmpty(sheetData);
                    if (rows != null && rows.Any())
                    {
                        List<int> emptyRowIndexes = rows.Where(row => row != null && (int)row.RowIndex.Value >= startRow && row.Descendants<Cell>().All(cell => cell != null && string.IsNullOrEmpty(GetCellValue(spreadsheetDocument, cell))))
                                                        ?.Select(x => (int)x.RowIndex.Value).ToList();

                        if (emptyRowIndexes != null && emptyRowIndexes.Count > 0)
                            rowsToDelete.AddRange(emptyRowIndexes);

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
                        DrawColumnName(sheetData, nameColError, startColError, startRowError);

                        WriteErrorMessage(workbookPart, sheetData, errorData, startColError, colHex);
                        worksheetPart.Worksheet.Save();
                    }
                }

                byte[] updatedFileBytes = ms.ToArray();
                return updatedFileBytes;
            }
        }

        private static void DrawColumnName(SheetData sheetData, string nameColError, uint startColError, uint startRowError)
        {
            string cellReference = GetCellReference(startColError, startRowError);
            Cell cellFormat = InsertOrUpdateCellInWorksheet(cellReference, sheetData);

            cellFormat.CellValue = new CellValue(nameColError);
            cellFormat.DataType = new EnumValue<CellValues>(CellValues.String);
        }

        private static string GetCellReference(uint columnIndex, uint rowIndex)
        {
            return GetColumnName(columnIndex) + rowIndex;
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

        private static void WriteErrorMessage(WorkbookPart workbookPart, SheetData sheetData, Dictionary<int, string> errorData, uint startColError, string colHex)
        {
            foreach (var err in errorData)
            {
                string cellReference = GetCellReference(startColError, (uint)err.Key);
                Cell cellFormat = InsertOrUpdateCellInWorksheet(cellReference, sheetData);

                cellFormat.CellValue = new CellValue(err.Value);
                cellFormat.DataType = new EnumValue<CellValues>(CellValues.String);

                // Add style red color
                uint redFontId = InsertFont(workbookPart, colHex);
                cellFormat.StyleIndex = InsertCellFormat(workbookPart, redFontId);
            }
        }

        private static uint InsertFont(WorkbookPart workbookPart, string fontColor)
        {
            var stylesheet = workbookPart.WorkbookStylesPart.Stylesheet;

            var fonts = stylesheet.Elements<Fonts>().FirstOrDefault();
            if (fonts == null)
            {
                fonts = new Fonts();
                stylesheet.InsertAt(fonts, 0);
            }

            var font = new Font();
            var color = new Color() { Rgb = new HexBinaryValue(fontColor) };
            font.AppendChild(color);
            fonts.AppendChild(font);

            return (uint)fonts.ChildElements.Count - 1;
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

        public static bool IsCellNullOrEmpty(string dataCell)
        {
            if (!string.IsNullOrEmpty(dataCell) && !string.IsNullOrWhiteSpace(dataCell))
            {
                return false;
            }

            return true;
        }
        private static IEnumerable<Row> GetAllRowsIncludingEmpty(SheetData sheetData)
        {
            // Read all rows from SheetData
            var rows = sheetData.Descendants<Row>().ToList();

            // Use a dictionary to map rows by their row index
            var rowDictionary = new Dictionary<uint, Row>();
            foreach (var row in rows)
            {
                var rowIndex = row.RowIndex;
                if (!rowDictionary.ContainsKey(rowIndex))
                {
                    rowDictionary[rowIndex] = row;
                }
            }

            // Determine the maximum row index
            var maxRowIndex = rowDictionary.Keys.Max();

            // Collect all rows, including empty ones
            for (uint i = 1; i <= maxRowIndex; i++)
            {
                if (rowDictionary.ContainsKey(i))
                {
                    yield return rowDictionary[i];
                }
                else
                {
                    // Create an empty row if it doesn't exist
                    yield return new Row { RowIndex = i };
                }
            }
        }


    }
}
