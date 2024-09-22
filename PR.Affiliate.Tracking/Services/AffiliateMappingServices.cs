using System.Globalization;
using System.Text.RegularExpressions;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Handler;
using GoSell.Affiliate.Tracking.Models.Mapping;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.Utils;
using GoSell.Library.Helpers.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Serilog;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateMappingServices : IAffiliateMappingServices
    {
        private ILogger<AffiliateMappingServices> Logger;
        private readonly IAffiliateRepository<AffiliateMapping> _affiliateMappingRepository;
        private readonly IStringLocalizer<ExportSubmissionCommandHandler> _localizer;
        private readonly IBaseApi _baseApi;
        public AffiliateMappingServices(
            ILogger<AffiliateMappingServices> logger,
            IAffiliateRepository<AffiliateMapping> affiliateMappingRepository,
                IBaseApi baseApi,
            IStringLocalizer<ExportSubmissionCommandHandler> localizer
           )
        {
            Logger = logger;
            _baseApi = baseApi;
            _affiliateMappingRepository = affiliateMappingRepository;
            _localizer = localizer;
        }

        public async Task<bool> CreateListMapping(List<AffiliateMapping> affiliateMapping, CancellationToken cancellationToken)
        {
            try
            {

                _affiliateMappingRepository.AddRange(affiliateMapping);
                await _affiliateMappingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateListMapping)}");
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateListMapping)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AffiliateMapping>> GetListAffiliateMappingByAffiliateStoreId(long affiliateStoreId)
        {
            return await _affiliateMappingRepository.Filter(x => x.IsDeleted == false && x.AffiliateStoreId == affiliateStoreId).ToListAsync();
        }

        public async Task<bool> RemoveAllMapingByAffiliateStoreId(long affiliateStoreId, CancellationToken cancellationToken)
        {
            try
            {
                var lstMapping = await _affiliateMappingRepository.Filter(x => x.AffiliateStoreId == affiliateStoreId).ToListAsync();
                lstMapping.ForEach(x => x.IsDeleted = true);
                _affiliateMappingRepository.UpdateRange(lstMapping);
                await _affiliateMappingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateListMapping)}");
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateListMapping)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public bool IsRowValidateEmpty(ExcelWorksheet worksheet, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row)
        {
            if ((affiliateOrderExcelMapping.ColMappingOrderId != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingTaxAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTaxAmount].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingShippingFee != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingShippingFee].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingDiscountAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingDiscountAmount].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingSubTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSubTotalAmount].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalAmount].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingPaymentMethod != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPaymentMethod].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingOrderCreatedDate != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingStatus != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingStatus].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingProductName != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductName].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingProductId != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductId].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingSellingPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSellingPrice].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingQuantity != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingQuantity].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingUnitPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingUnitPrice].Value == null) &&
                (affiliateOrderExcelMapping.ColMappingTotalPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalPrice].Value == null)
               )
            {
                return true;
            }
            return false;
        }

        public List<string> RowValidateSubmisison(ExcelWorksheet worksheet, List<AffiliateProduct> affiliateProducts, long externalStoreId, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row)
        {
            var result = new List<string>();
            if (affiliateOrderExcelMapping.ColMappingOrderId == null || worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value == null)
            {
                result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.missing"),
                        GetLocalizedValue("export.orderExternalStore.filedName.orderID")));
            }
            else
            {
                string orderId = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString();
                if (orderId.Length > 50)
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.exceedsMaxLength"),
                        GetLocalizedValue("export.orderExternalStore.filedName.orderID")));
                }
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                if (!regexItem.IsMatch(orderId))
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                                GetLocalizedValue("export.orderExternalStore.filedName.orderID")));
                }
            }

            if (affiliateOrderExcelMapping.ColMappingProductId == null || worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductId].Value == null)
            {
                result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.missing"),
                        GetLocalizedValue("export.orderExternalStore.filedName.productId")));
            }
            else
            {
                string productId = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductId].Value.ToString();
                if (productId.ToString().Length > 50)
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.exceedsMaxLength"),
                        GetLocalizedValue("export.orderExternalStore.filedName.productId")));
                }
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                if (!regexItem.IsMatch(productId))
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                                GetLocalizedValue("export.orderExternalStore.filedName.productId")));
                }

            }
            if (affiliateOrderExcelMapping.ColMappingProductName != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductName].Value != null)
                if (worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductName].Value.ToString().Length > 200)
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.exceedsMaxLength"),
                        GetLocalizedValue("export.orderExternalStore.filedName.productName")));
                }
            if (affiliateOrderExcelMapping.ColMappingSellingPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSellingPrice].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSellingPrice].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                             GetLocalizedValue("export.orderExternalStore.filedName.sellingPrice"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.sellingPrice"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.sellingPrice")));
            if (affiliateOrderExcelMapping.ColMappingUnitPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingUnitPrice].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingUnitPrice].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                             GetLocalizedValue("export.orderExternalStore.filedName.unitPrice"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.unitPrice"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.unitPrice")));
            if (affiliateOrderExcelMapping.ColMappingTotalPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalPrice].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalPrice].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                             GetLocalizedValue("export.orderExternalStore.filedName.totalPrice"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.totalPrice"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.totalPrice")));
            if (affiliateOrderExcelMapping.ColMappingQuantity != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingQuantity].Value != null)
                if (long.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingQuantity].Value.ToString(), out long data))
                {
                    if (data > 99999999)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.quantity"), "99,999,999"));
                    }
                    else if (data < 1)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.quantity"), "1"));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.quantity")));
            if (affiliateOrderExcelMapping.ColMappingTaxAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTaxAmount].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTaxAmount].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.tax"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.tax"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.tax")));
            if (affiliateOrderExcelMapping.ColMappingShippingFee != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingShippingFee].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingShippingFee].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.shippingFee"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.shippingFee"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.shippingFee")));
            if (affiliateOrderExcelMapping.ColMappingDiscountAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingDiscountAmount].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingDiscountAmount].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.discountAmount"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.discountAmount"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.discountAmount")));
            if (affiliateOrderExcelMapping.ColMappingSubTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSubTotalAmount].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSubTotalAmount].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.subTotalAmount"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.subTotalAmount"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"),
                        GetLocalizedValue("export.orderExternalStore.filedName.subTotalAmount")));
            if (affiliateOrderExcelMapping.ColMappingTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalAmount].Value != null)
                if (decimal.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalAmount].Value.ToString(), out decimal data))
                {
                    if (data > (decimal)99999999.99)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.greaterThanMax"),
                            GetLocalizedValue("export.orderExternalStore.filedName.totalAmount"), "99,999,999.99"));
                    }
                    else if (data < 0)
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.smallerThanMin"),
                            GetLocalizedValue("export.orderExternalStore.filedName.totalAmount"), 0));
                    }
                }
                else
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"), GetLocalizedValue("export.orderExternalStore.filedName.totalAmount")));
            if (affiliateOrderExcelMapping.ColMappingPaymentMethod != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPaymentMethod].Value != null)
            {
                string paymentMethod = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPaymentMethod].Value.ToString();
                if (paymentMethod.ToString().Length > 200)
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.exceedsMaxLength"),
                    GetLocalizedValue("export.orderExternalStore.filedName.paymentMethod")));
                }
            }


            if (affiliateOrderExcelMapping.ColMappingOrderCreatedDate == null || worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value == null)
            {
                result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.missing"),
                        GetLocalizedValue("export.orderExternalStore.filedName.orderDate")));
            }
            else if (affiliateOrderExcelMapping.ColMappingOrderCreatedDate != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value != null)
            {
                var date = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value;
                if (date.GetType().Name == "String")
                {
                    if (!DateTime.TryParseExact(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value.ToString(), ["dd/MM/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "dd-MM-yyyy HH:mm:ss", "d-M-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "d/M/yyyy HH:mm", "dd-MM-yyyy HH:mm", "d-M-yyyy HH:mm"], CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime orderCreatedDate))
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidDateTimeFormat"), GetLocalizedValue("export.orderExternalStore.filedName.orderDate")));

                }
                else
                {
                    try
                    {
                        DateTime.FromOADate((double)date);
                    }
                    catch
                    {
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"), GetLocalizedValue("export.orderExternalStore.filedName.orderDate")));
                    }

                }
            }
            if (affiliateOrderExcelMapping.ColMappingStatus != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingStatus].Value != null)
            {
                if (Int32.TryParse(worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingStatus].Value.ToString(), out int data))
                {
                    SubmissionStatusEnum submissionStatus = (SubmissionStatusEnum)data;
                    if (!Enum.IsDefined(typeof(SubmissionStatusEnum), submissionStatus))
                        result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.invalidFormat"), GetLocalizedValue("export.orderExternalStore.filedName.status")));
                }

            }

            if (affiliateOrderExcelMapping.ColMappingPublisher != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPublisher].Value != null)
            {
                string publisherPhone = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPublisher].Value.ToString();
                if (publisherPhone.ToString().Length > 15)
                {
                    result.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.exceedsMaxLength"),
                        GetLocalizedValue("export.orderExternalStore.filedName.publisherPhone")));
                }

            }

            return result;

        }

        public AffiliateSubmission BuildSubmission(ExcelWorksheet worksheet, long externalStoreId, AffiliateOrderExcelMapping affiliateOrderExcelMapping, int row, TimeZoneInfo clientTimeZone, AffiliateSubmission affiliateSubmisson = null)
        {
            AffiliateSubmission newSubmission;
            if (affiliateSubmisson != null)
            {
                newSubmission = affiliateSubmisson;
            }
            else
            {
                newSubmission = new AffiliateSubmission();
            }

            if (affiliateOrderExcelMapping.ColMappingOrderId != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value != null)
                newSubmission.OrderId = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingTaxAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTaxAmount].Value != null)
                newSubmission.TaxAmount = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTaxAmount].Value.ToString().ExtensionGetValueColToDecimal(newSubmission.TaxAmount);

            if (affiliateOrderExcelMapping.ColMappingShippingFee != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingShippingFee].Value != null)
                newSubmission.ShippingFee = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingShippingFee].Value.ToString().ExtensionGetValueColToDecimal(newSubmission.ShippingFee);

            if (affiliateOrderExcelMapping.ColMappingDiscountAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingDiscountAmount].Value != null)
                newSubmission.DiscountAmount = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingDiscountAmount].Value.ToString().ExtensionGetValueColToDecimal(newSubmission.DiscountAmount);

            if (affiliateOrderExcelMapping.ColMappingSubTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSubTotalAmount].Value != null)
                newSubmission.SubTotalAmount = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSubTotalAmount].Value.ToString().ExtensionGetValueColToDecimal(newSubmission.SubTotalAmount);

            if (affiliateOrderExcelMapping.ColMappingTotalAmount != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalAmount].Value != null)
                newSubmission.TotalAmount = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalAmount].Value.ToString().ExtensionGetValueColToDecimal(newSubmission.TotalAmount);

            if (affiliateOrderExcelMapping.ColMappingPaymentMethod != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPaymentMethod].Value != null)
                newSubmission.PaymentMethod = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingPaymentMethod].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingOrderCreatedDate != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value != null)
            {
                var date = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingOrderCreatedDate].Value;
                if (date.GetType().Name == "String")
                {
                    newSubmission.OrderCreatedDate = TimeZoneInfo.ConvertTimeToUtc(date.ToString().ExtensionGetValueColToDateTime(newSubmission.OrderCreatedDate), clientTimeZone);
                }
                else
                {
                    newSubmission.OrderCreatedDate = TimeZoneInfo.ConvertTimeToUtc(DateTime.FromOADate((double)date), clientTimeZone);
                }
            }

            if (affiliateOrderExcelMapping.ColMappingStatus != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingStatus].Value != null)
                newSubmission.Status = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingStatus].Value.ToString().ExtensionGetValueColStatus(newSubmission.Status);

            if (affiliateOrderExcelMapping.ColMappingCustomerName != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerName].Value != null)
                newSubmission.CustomerName = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerName].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingCustomerPhone != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerPhone].Value != null)
                newSubmission.CustomerPhone = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerPhone].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingCustomerAddress != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerAddress].Value != null)
                newSubmission.CustomerAddress = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingCustomerAddress].Value.ToString();

            newSubmission.ExternalStoreId = externalStoreId;

            if (affiliateSubmisson == null)
            {
                newSubmission.CreatedBy = _baseApi.User.Sub;
                newSubmission.CreatedDate = DateTime.UtcNow;
            }
            newSubmission.LastModifiedBy = _baseApi.User.Sub;
            newSubmission.LastModifiedDate = DateTime.UtcNow;
            if (newSubmission.AffiliateOrderDetails == null)
            {
                newSubmission.AffiliateOrderDetails = new List<AffiliateOrderDetail>();
            }
            newSubmission.AffiliateOrderDetails.Add(BuildOrderDetail(worksheet, row, affiliateOrderExcelMapping));

            return newSubmission;
        }

        public AffiliateOrderDetail BuildOrderDetail(ExcelWorksheet worksheet, int row, AffiliateOrderExcelMapping affiliateOrderExcelMapping)
        {
            var newOrderDetail = new AffiliateOrderDetail();
            if (affiliateOrderExcelMapping.ColMappingProductId != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductId].Value != null)
                newOrderDetail.ProductId = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductId].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingProductName != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductName].Value != null)
                newOrderDetail.ItemName = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingProductName].Value.ToString();

            if (affiliateOrderExcelMapping.ColMappingSellingPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSellingPrice].Value != null)
                newOrderDetail.SalePrice = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingSellingPrice].Value.ToString().ExtensionGetValueColToDecimal(newOrderDetail.SalePrice);
            if (affiliateOrderExcelMapping.ColMappingUnitPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingUnitPrice].Value != null)
                newOrderDetail.Price = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingUnitPrice].Value.ToString().ExtensionGetValueColToDecimal(newOrderDetail.Price);
            if (affiliateOrderExcelMapping.ColMappingTotalPrice != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalPrice].Value != null)
                newOrderDetail.TotalPrice = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingTotalPrice].Value.ToString().ExtensionGetValueColToDecimal(newOrderDetail.TotalPrice);
            if (affiliateOrderExcelMapping.ColMappingQuantity != null && worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingQuantity].Value != null)
                newOrderDetail.Quantity = worksheet.Cells[row, (int)affiliateOrderExcelMapping.ColMappingQuantity].Value.ToString().ExtensionGetValueColToLong(newOrderDetail.Quantity);
            newOrderDetail.CreatedBy = _baseApi.User.Sub;
            newOrderDetail.CreatedDate = DateTime.UtcNow;
            newOrderDetail.LastModifiedBy = _baseApi.User.Sub;
            newOrderDetail.LastModifiedDate = DateTime.UtcNow;
            return newOrderDetail;
        }


        private string GetLocalizedValue(string key, string defaultValue = "")
        {
            var localized = _localizer[key];
            return !string.IsNullOrEmpty(localized?.Value) && !localized.ResourceNotFound ? localized.Value : (!string.IsNullOrEmpty(defaultValue) ? defaultValue : key);
        }

    }
}
