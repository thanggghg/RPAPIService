using System.Globalization;
using RP.Common.Constants;
using RP.Common.Models.Requests;
using RP.Common.Models.Responses;
using RP.Common.Queries;
using RP.Common.Services.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Serilog;
using static RP.Common.Services.DelegateService;

namespace RP.Common.Services.Implements.ExportCommon
{
    public class ExportCommonService<T> : IExportCommonService<T> where T : class
    {
        private readonly ExportDataMapperResolver<IDataMapperExportService<T>> _serviceResolver;

        public ExportCommonService(ExportDataMapperResolver<IDataMapperExportService<T>> serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public async Task<ExportCommonQueryResponse> ProcessAsync(ExportCommonQuery<T> exportQuery)
        {
            try
            {
                IDataMapperExportService<T> service = _serviceResolver(exportQuery.ExportType.ToString()) ?? throw new Exception("No service register. Please check!");

                InitializeExportCommonData exportData = await service.GetExportDataAsync(exportQuery);

                byte[] file = HandleExportToExcel(exportData);

                ExportCommonQueryResponse exportQueryResult = new()
                {
                    File = file,
                    TemplateType = exportData.TemplateType,
                    TemplateName = exportData.TemplateName,
                };

                return exportQueryResult;
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Export failed:: {e.Message}");
                throw new Exception("Export failed: " + e.ToString());
            }
        }

        private static byte[] HandleExportToExcel(InitializeExportCommonData exportData)
        {
            try
            {
                using var memory = new MemoryStream();
                using var excelPackage = new ExcelPackage(memory);
                foreach (var sheet in exportData.Sheets)
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add(sheet.SheetName);
                    int currentRowIndex = sheet.startRowIndex;
                    ExportTable(workSheet, ref currentRowIndex, sheet);
                }
                excelPackage.Save();
                return memory.ToArray();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw new Exception("Export CashBook To Excel failed: " + e.ToString());
            }
        }

        private static void ExportTable(ExcelWorksheet workSheet, ref int currentRowIndex, ExportSheet sheet)
        {
            if (sheet.Titles != null && sheet.Titles.Count != 0)
            {
                BuildTitles(workSheet, sheet.Titles);
            }

            if (sheet.Headers != null && sheet.Headers.Count != 0)
            {
                BuildHeaders(workSheet, sheet.Headers, currentRowIndex, sheet.HiddenColumns, sheet.HeaderStyle);
            }

            if (sheet.DataItems != null && sheet.DataItems.Count != 0)
            {
                foreach (var item in sheet.DataItems)
                {
                    if (item.Items != null && item.Items.Count != 0)
                    {
                        ++currentRowIndex;
                        for (int i = 0; i < item.Items.Count; i++)
                        {
                            var itemData = item.Items[i];
                            ExportCellData(workSheet, sheet, currentRowIndex, itemData, sheet.HiddenColumns);
                        }
                    }
                }
            }

            if (sheet.Footers != null && sheet.Footers.Count > 0)
            {
                ++currentRowIndex;
                foreach (var footer in sheet.Footers)
                {
                    ExportCellData(workSheet, sheet, currentRowIndex, footer, sheet.HiddenColumns);
                }
            }
            workSheet.Cells.AutoFitColumns();
        }

        private static void ExportCellData(ExcelWorksheet workSheet, ExportSheet sheet, int currentRowIndex, ExportDataItem itemData, List<int> hiddenColumns)
        {
            var cell = workSheet.Cells[currentRowIndex, itemData.Order];
            cell.Value = itemData.DisplayText;

            if (hiddenColumns.Contains(itemData.Order))
            {
                workSheet.Column(itemData.Order).Hidden = true;
                return;
            }

            string cellType = sheet.Headers.FirstOrDefault(x => x.Code == itemData.Code)?.Type;

            if (cellType == ExportCommonConstant.NUMBER)
            {
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
            else if (cellType == ExportCommonConstant.DATE && DateTime.TryParseExact(itemData.DisplayText, "dd/MM/yyyy HH:mm:ss", null, DateTimeStyles.None, out DateTime originalDateTime) && sheet.isCustomColumnType)
            {
                cell.Value = originalDateTime.Date.ToString("dd/MM/yyyy");
            }
        }

        private static void BuildTitles(ExcelWorksheet workSheet, List<Title> titles)
        {
            if (titles.Count != 0)
            {
                foreach (var title in titles)
                {
                    var titleCell = workSheet.Cells[title.RowOrder, title.ColumnOrder];
                    titleCell.Value = title.Caption;
                    titleCell.Style.Font.Bold = title.FontBold;
                    titleCell.Style.Font.Size = title.FontSize;
                }
            }
        }

        private static void BuildHeaders(ExcelWorksheet workSheet, List<Header> headers, int rowIndex, List<int> hiddenColumns, HeaderStyle headerStyle)
        {
            if (headers.Count != 0)
            {
                foreach (var item in headers)
                {
                    var cell = workSheet.Cells[rowIndex, item.Order];
                    cell.Value = item.Caption;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Font.Color.SetColor(headerStyle.FontColor);
                    cell.Style.Fill.BackgroundColor.SetColor(headerStyle.BackgroundColor);
                }

                if (hiddenColumns.Count != 0)
                {
                    hiddenColumns.ForEach(x =>
                    {
                        if (workSheet.Columns[x] != null)
                        {
                            workSheet.Columns[x].Hidden = true;
                        }
                    });
                }
            }
        }
    }
}
