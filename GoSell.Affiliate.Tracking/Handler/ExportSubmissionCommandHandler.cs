using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class ExportSubmissionCommandHandler : IRequestHandler<ExportSubmissionCommand, FileDataViewModel>
    {
        private readonly ILogger<GetAllAffiliateBusinessQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IStringLocalizer<ExportSubmissionCommandHandler> _localizer;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly IBaseApi _baseApi;

        public ExportSubmissionCommandHandler(ILogger<GetAllAffiliateBusinessQueryHandler> logger,
                                           IMapper mapper,
                                           IAffiliateSubmissionServices affiliateSubmissionServices,
                                           IWebHostEnvironment hostingEnvironment,
                                           IAffiliateStoreServices affiliateStoreServices,
                                           IStringLocalizer<ExportSubmissionCommandHandler> localizer,
                                           IBaseApi baseApi)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
            _affiliateStoreServices = affiliateStoreServices;
            _baseApi = baseApi;
        }

        public async Task<FileDataViewModel> Handle(ExportSubmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Add a new worksheet to the Excel package
                string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Templates", request.Langkey, "Order_Export.xlsx");
                FileInfo existingFile = new FileInfo(filePath);

                ExcelPackage package = new ExcelPackage(existingFile);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                var affStoreIds = _affiliateStoreServices.GetAllAffiliateStoreByGoSellId(request.IsStoreDeleted, _baseApi.User.StoreId).Result.Select(x => x.Id).ToList();
                if (affStoreIds.Count == 0 || (request.ExternalStoreId != null && !affStoreIds.Contains((long)request.ExternalStoreId)))
                {
                    return await Task.FromResult(new FileDataViewModel(new MemoryStream(package.GetAsByteArray()), string.Format(GetLocalizedValue("export.orderExternalStore.fileName"), DateTime.UtcNow.ToString("ddMMyyyy_HHmmss"))));
                }
                List<string> HeaderTitle = ["ORDER ID", "APPROVAL STATUS", "TOTAL AMOUINT", "PAYMENT METHOD", "ORDER DATE"];
                var filter = new FilterDataExportOrderByStoreId()
                {
                    TypeId = request.TypeId,
                    ExternalStoreIds = affStoreIds,
                    PageNumber = 1,
                    PageSize = 5000,
                    SearchString = request.SearchString,
                    SearchType = request.SearchType,
                    ApprovalStatus = request.ApprovalStatus,
                    FromDate = request.FromDate,
                    ToDate = request.ToDate,
                    ClientTimeZone = request.ClientTimeZone,
                };

                List<ExportOrderSubmissionViewModel> listOrderDetail = await _affiliateSubmissionServices.GetDataExportOrderByStoreId(filter, cancellationToken);

                int row = 2;
                foreach (var dataRow in listOrderDetail)
                {
                    worksheet.Cells[row, 1].Value = dataRow.OrderId;
                    worksheet.Cells[row, 2].Value = dataRow.ProductName;
                    worksheet.Cells[row, 3].Value = dataRow.ProductId;
                    worksheet.Cells[row, 4].Value = dataRow.Price;
                    worksheet.Cells[row, 5].Value = dataRow.SalePrice;
                    worksheet.Cells[row, 6].Value = dataRow.Quantity;
                    worksheet.Cells[row, 7].Value = dataRow.TotalPrice;
                    worksheet.Cells[row, 8].Value = dataRow.Tax;
                    worksheet.Cells[row, 9].Value = dataRow.ShippingFee;
                    worksheet.Cells[row, 10].Value = dataRow.DiscountAmount;
                    worksheet.Cells[row, 11].Value = dataRow.SubTotalAmount;
                    worksheet.Cells[row, 12].Value = dataRow.TotalAmount;
                    worksheet.Cells[row, 13].Value = dataRow.PaymentMethod;
                    worksheet.Cells[row, 14].Value = dataRow.OrdateDate;
                    worksheet.Cells[row, 15].Value = GetLocalizedValue(string.Format("export.orderExternalStore.exportSubmission.approvalStatus.{0}", dataRow.ApprovalStatus), "");
                    worksheet.Cells[row, 16].Value = dataRow.PartnerPhone;
                    worksheet.Cells[row, 17].Value = dataRow.CustomerName;
                    worksheet.Cells[row, 18].Value = dataRow.CustomerPhone;
                    worksheet.Cells[row, 19].Value = dataRow.CustomerAddress;
                    row++;
                }
                var stream = new MemoryStream(package.GetAsByteArray());
                string fileName = string.Format(GetLocalizedValue("export.orderExternalStore.fileName"), DateTime.UtcNow.ToString("ddMMyyyy_HHmmss"));
                return await Task.FromResult(new FileDataViewModel(stream, fileName));

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateBusinessQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private string GetLocalizedValue(string key, string defaultValue = "")
        {
            var localized = _localizer[key];
            return !string.IsNullOrEmpty(localized?.Value) && !localized.ResourceNotFound ? localized.Value : (!string.IsNullOrEmpty(defaultValue) ? defaultValue : key);
        }

    }
}
