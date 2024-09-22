using System.Globalization;
using System.Reflection;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Constants;
using GoSell.Common.Helpers;
using GoSell.Common.Models.Requests;
using GoSell.Common.Queries;
using GoSell.Common.Services.Interfaces;
using Microsoft.Extensions.Localization;
using Serilog;

namespace GoSell.Affiliate.Tracking.Services.ExportAffiliateUrlReport
{
    public class ExportAffiliateUrlReportService : IDataMapperExportService<ExportAffUrlReportQuery>
    {
        private readonly IStringLocalizer<ExportAffiliateUrlReportService> _localizer;

        public ExportAffiliateUrlReportService(IStringLocalizer<ExportAffiliateUrlReportService> localizer)
        {
            _localizer = localizer;
        }


        public async Task<InitializeExportCommonData> GetExportDataAsync(ExportCommonQuery<ExportAffUrlReportQuery> exportQuery)
        {
            try
            {
                if (exportQuery != null && exportQuery?.AdditionData?.ExportData?.Count > 0)
                {

                    var headers = CreateOrderCommissionReportHeader();

                    string sheetName = GetLocalizedValue(LocalizationExportCommonConstants.URL_REPORT_TEMPLATE_SHEETNAME);
                    string fileName = GetLocalizedValue(LocalizationExportCommonConstants.URL_REPORT_TEMPLATE_FILENAME);
                    string fileType = Helpers.GetTemplateType(fileName);

                    HeaderStyle headerStyle = new HeaderStyle()
                    {
                        FontColor = AffUrlReportConstants.HEADER_FONT_COLOR,
                        BackgroundColor = AffUrlReportConstants.HEADER_BACKGROUND_COLOR
                    };

                    List<ExportSheet> sheets =
                    [
                        new()
                        {
                            SheetName = sheetName,
                            Headers = headers,
                            HeaderStyle = headerStyle,
                            DataItems = await CreateDataItemAsync(headers, exportQuery?.AdditionData.ExportData, exportQuery?.AdditionData.CurrencyCode),
                            startRowIndex = 1,
                            isCustomColumnType = false
                        }
                    ];

                    return new InitializeExportCommonData
                    {
                        Sheets = sheets,
                        TemplateType = fileType,
                        TemplateName = fileName
                    };
                }
                else
                {
                    throw new ArgumentException("Invalid JSON format in export conditions.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Export failed: " + e.Message);
            }
        }

        private List<Header> CreateOrderCommissionReportHeader()
        {
            string prefixKey = LocalizationExportCommonConstants.URL_REPORT_CAPTION;
            List<Header> headers =
            [
                new Header() { Code = AffUrlReportColumnConstants.TRACKING_URL, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.TRACKING_URL}"] ?? String.Empty, Order = 1, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.CREATED_DATE, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.CREATED_DATE}"] ?? String.Empty, Order = 2, Type = ExportCommonConstant.DATE },
                new Header() { Code = AffUrlReportColumnConstants.PRODUCT_NAME, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.PRODUCT_NAME}"] ?? String.Empty, Order = 3, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.CAMPAIGN_NAME, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.CAMPAIGN_NAME}"] ?? String.Empty, Order = 4, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.SUB_01, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.SUB_01}"] ?? String.Empty, Order = 5, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.SUB_02, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.SUB_02}"] ?? String.Empty, Order = 6, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.SUB_03, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.SUB_03}"] ?? String.Empty, Order = 7, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.SUB_04, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.SUB_04}"] ?? String.Empty, Order = 8, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.SUB_05, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.SUB_05}"] ?? String.Empty, Order = 9, Type = ExportCommonConstant.TEXT },
                new Header() { Code = AffUrlReportColumnConstants.NUM_OF_CLICK, Caption = _localizer[$"{prefixKey}{AffUrlReportColumnConstants.NUM_OF_CLICK}"] ?? String.Empty, Order = 10, Type = ExportCommonConstant.NUMBER },
            ];

            return headers;
        }

        private async Task<List<ExportData>> CreateDataItemAsync(List<Header> headers, List<AffiliateUrlModel> affUrlReports, string currencyCode)
        {
            try
            {
                int trunkSize = 100;
                List<ExportData> dataItems = new List<ExportData>();
                var culture = new CultureInfo("en-US");
                for (int i = 0; i < affUrlReports.Count; i += trunkSize)
                {
                    List<AffiliateUrlModel> trunk = affUrlReports.Skip(i).Take(trunkSize).ToList();
                    List<Task<ExportDataItem[]>> tasks = new List<Task<ExportDataItem[]>>();
                    foreach (AffiliateUrlModel affUrlReport in trunk)
                    {
                        Task<ExportDataItem[]> task = Task.Run(() =>
                        {
                            List<ExportDataItem> items = new List<ExportDataItem>();
                            foreach (Header header in headers)
                            {
                                items.Add(new ExportDataItem()
                                {
                                    Code = header.Code,
                                    Order = header.Order,
                                    DisplayText = GetCellValueWithHeaderCode(header, affUrlReport, currencyCode, culture)
                                });
                            }
                            return items.ToArray();
                        });

                        tasks.Add(task);
                    }

                    ExportDataItem[][] trunkItemsArray = await Task.WhenAll(tasks);
                    List<ExportData> trunkDataItems = trunkItemsArray.Select(trunkItems => new ExportData() { Items = trunkItems.ToList() }).ToList();
                    dataItems.AddRange(trunkDataItems);
                }
                return dataItems;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw new Exception("Create AffUrlReport Data Item failed: " + e.ToString());
            }
        }

        private string GetCellValueWithHeaderCode(Header header, AffiliateUrlModel affUrlReport, string currencyCode, CultureInfo culture)
        {
            try
            {
                string columnValue;
                var numberFormat = CurrencyConstants.VND.Equals(currencyCode) ? CurrencyFormats.VND : CurrencyFormats.OTHER;
                switch (header.Code)
                {
                    case AffUrlReportColumnConstants.CREATED_DATE:
                        columnValue = Helpers.ConvertDateTimeToString(affUrlReport.CreatedDate, "dd/MM/yyyy HH:mm:ss");
                        break;
                    case AffUrlReportColumnConstants.NUM_OF_CLICK:
                        columnValue = Helpers.FormatNumber(affUrlReport.TotalClick, numberFormat, culture);
                        break;

                    default:
                        PropertyInfo property = affUrlReport.GetType().GetProperties()
                                .FirstOrDefault(p => string.Equals(p.Name, header.Code, StringComparison.OrdinalIgnoreCase));
                        columnValue = property != null ? property.GetValue(affUrlReport)?.ToString() : string.Empty;
                        break;
                }

                return columnValue;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, e.Message);
                throw new Exception("Get Cell Value With HeaderCode failed: " + e.ToString());
            }
        }

        private string GetLocalizedValue(string key, string defaultValue = "")
        {
            var localized = _localizer[key];
            return !string.IsNullOrEmpty(localized?.Value) && !localized.ResourceNotFound ? localized.Value : (!string.IsNullOrEmpty(defaultValue) ? defaultValue : key);
        }
    }
}
