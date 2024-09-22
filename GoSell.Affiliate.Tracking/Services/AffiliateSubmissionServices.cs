using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq.Expressions;
using AutoMapper;
using GoSell.Affiliate.Authentication.Domain.Entities.Affiliate;
using GoSell.Affiliate.Authentication.Domain.Repositories;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Handler;
using GoSell.Affiliate.Tracking.Models.Mapping;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.Utils;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Models;
using GoSell.CommonHistory.Commons.Enums;
using GoSell.Library.Db;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Utils;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Serilog;


namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateSubmissionServices : IAffiliateSubmissionServices
    {
        private readonly ILogger<AffiliateSubmissionServices> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateRepository<AffiliateSubmission> _affiliateSubmissionRepository;
        private readonly IAffiliateRepository<AffiliateOrderDetail> _affiliateOrderDetailRepository;
        private readonly IAffiliateRepository<AffiliateProduct> _affiliateProductRepository;
        private readonly IAffiliateRepository<AffiliateMapping> _affiliateMappingRepository;
        private readonly IAffiliateRepository<AffiliateOrderTracking> _affiliateOrderTrackingRepository;
        private readonly IAffiliateMappingServices _affiliateMappingServices;
        private readonly IAffiliateAuthRepository<AffiliateUserStore> _affiliateUserStoreRepository;
        private readonly AffiliateContext _affiliateContext;
        private readonly IStringLocalizer<ExportSubmissionCommandHandler> _localizer;
        private readonly IAffiliateRepository<AffiliateClickTracking> _affiliateClickTrackingRepository;
        private readonly IAffiliateRepository<AffiliateTrackingManagement> _affiliateTrackingManagementRepository;
        private readonly IAffiliatePartnerServices _affiliatePartnerServices;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly IBaseApi _baseApi;
        private readonly AffiliateStore _affStore;
        private readonly IAffiliateRepository<AffiliateLink> _affiliateLinkRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IConfiguration _configuration;

        public AffiliateSubmissionServices(ILogger<AffiliateSubmissionServices> logger,
                                           IMapper mapper,
                                           IAffiliateRepository<AffiliateSubmission> affiliateSubmissionRepository,
                                           IAffiliateRepository<AffiliateOrderDetail> affiliateOrderDetailRepository,
                                           IAffiliateRepository<AffiliateProduct> affiliateProductRepository,
                                           IAffiliateRepository<AffiliateMapping> affiliateMappingRepository,
                                           IAffiliateMappingServices affiliateMappingServices,
                                           AffiliateContext affiliateContext,
                                           IStringLocalizer<ExportSubmissionCommandHandler> localizer,
                                           IAffiliateRepository<AffiliateClickTracking> affiliateClickTrackingRepository,
                                           IAffiliateRepository<AffiliateTrackingManagement> affiliateTrackingManagementRepository,
                                           IAffiliatePartnerServices affiliatePartnerServices,
                                           IAffiliateStoreServices affiliateStoreServices,
                                           IAffiliateAuthRepository<AffiliateUserStore> affiliateUserStoreRepository,
                                           IAffiliateRepository<AffiliateLink> affiliateLinkRepository,
                                           IHttpContextAccessor httpContextAccessor,
                                           IHttpClientHelper httpClientHelper,
                                           IConfiguration configuration,
                                           IBaseApi baseApi,
                                           IAffiliateRepository<AffiliateOrderTracking> affiliateOrderTrackingRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateSubmissionRepository = affiliateSubmissionRepository;
            _affiliateOrderDetailRepository = affiliateOrderDetailRepository;
            _affiliateProductRepository = affiliateProductRepository;
            _affiliateMappingRepository = affiliateMappingRepository;
            _affiliateMappingServices = affiliateMappingServices;
            _affiliateContext = affiliateContext;
            _localizer = localizer;
            _affiliateClickTrackingRepository = affiliateClickTrackingRepository;
            _affiliateTrackingManagementRepository = affiliateTrackingManagementRepository;
            _affiliatePartnerServices = affiliatePartnerServices;
            _affiliateStoreServices = affiliateStoreServices;
            _baseApi = baseApi;
            _affiliateUserStoreRepository = affiliateUserStoreRepository;
            _affStore = _affiliateStoreServices.GetSpecificAffiliateByGoSellStoreId(_baseApi.User.StoreId).Result;
            _affiliateLinkRepository = affiliateLinkRepository;
            _httpContextAccessor = httpContextAccessor;
            _httpClientHelper = httpClientHelper;
            _configuration = configuration;
            _affiliateOrderTrackingRepository = affiliateOrderTrackingRepository;
        }

        public async Task<string> CreateAffiliateSubmission(AffiliateSubmission affiliateSubmission, List<AffiliateOrderDetail> affiliateOrderDetails, CancellationToken cancellationToken)
        {
            var submissionExist = _affiliateSubmissionRepository.Filter(x => x.ConversionId == affiliateSubmission.ConversionId).FirstOrDefault();
            if (submissionExist != null)
            {
                return nameof(SubmissionCodeEnum.EXSITED_CONVERSION);
            }
            submissionExist = _affiliateSubmissionRepository.Filter(x => x.OrderId == affiliateSubmission.OrderId && x.ExternalStoreId == affiliateSubmission.ExternalStoreId).FirstOrDefault();
            if (submissionExist != null)
            {
                return nameof(SubmissionCodeEnum.ORDER_ID_EXISTED);
            }

            try
            {

                await _affiliateSubmissionRepository.AddAsync(affiliateSubmission);
                await _affiliateSubmissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                if (affiliateOrderDetails != null && affiliateOrderDetails.Count > 0)
                {
                    affiliateOrderDetails.ForEach(item => item.SubmissionId = affiliateSubmission.Id);
                }

                _affiliateOrderDetailRepository.AddRange(affiliateOrderDetails);
                var result = await _affiliateOrderDetailRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateAffiliateSubmission)}");
                return result ? nameof(SubmissionCodeEnum.SUCCESS) : nameof(SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateSubmission)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaginatedList<AffiliateSubmissionViewModel>> GetAffiliateSubmissionGsByStoreId(GetAllAffiliateSubmissionByGsStoreIdQuery request)
        {
            var result = new PaginatedList<AffiliateSubmissionViewModel>(new List<AffiliateSubmissionViewModel>(), 0, request.PageNumber, request.PageSize);

            var affStores = await _affiliateStoreServices.GetAllAffiliateStoreByGsId(request.GsStoreId);
            if (request.AffStoreStatus != null)
            {
                affStores = affStores.Where(x => x.IsDeleted != request.AffStoreStatus).ToList();
            }

            if (affStores == null && affStores.Count() == 0)
            {
                return await Task.FromResult(result);
            }

            Dictionary<long, AffiliateStore> affiliateStoreDic = affStores.ToDictionary(p => p.Id);
            List<long> storeIds = affiliateStoreDic.Keys.ToList();

            var data = _affiliateSubmissionRepository.Filter(x => x.SubmissionType == request.TypeId
            && storeIds.Contains(x.ExternalStoreId)
            && (x.IsDeleted == false)
            && (request.ApprovalStatus == null || x.Status == request.ApprovalStatus)
            && (request.AffiliateStoreId == null || x.ExternalStoreId == request.AffiliateStoreId)
            && (request.FromDate == null || x.OrderCreatedDate.Date >= request.FromDate.Value.Date) && (request.ToDate == null || x.OrderCreatedDate <= request.ToDate.Value.Date));
            switch (request.SearchType)
            {
                case 0:
                    data = data.Where(x => x.OrderId.ToLower().Contains(request.SearchString.Trim().ToLower()));
                    break;
                default: break;
            }
            var paginatedData = data.OrderByDescending(x => x.LastModifiedDate).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            var resMapper = _mapper.Map<List<AffiliateSubmission>, List<AffiliateSubmissionViewModel>>(paginatedData);

            foreach (var submission in resMapper)
            {
                var _currentStore = affStores.FirstOrDefault(p => p.Id == submission.ExternalStoreId);
                if (_currentStore != null && _currentStore.AffiliateStoreCurrency != null)
                {
                    submission.CurrencySymbol = _currentStore.AffiliateStoreCurrency.Symbol;
                    submission.CurrencyCode = _currentStore.AffiliateStoreCurrency.Code;
                }
            };

            resMapper.ForEach((x) =>
            {
                x.AffiliateStoreName = affiliateStoreDic.TryGetValue(x.ExternalStoreId, out var store) ? store.Name : "";
            });
            var resultPaginated = new PaginatedList<AffiliateSubmissionViewModel>(resMapper, data.Count(), request.PageNumber, request.PageSize);

            return await Task.FromResult(resultPaginated);
        }

        public Task<AffiliateSubmission> GetAffiliateSubmissionBySubmissionId(long submissionId)
        {
            var submission = _affiliateSubmissionRepository.Filter(x => x.Id == submissionId, includes: [x => x.AffiliateOrderDetails]).FirstOrDefault();
            return Task.FromResult(submission);
        }

        public async Task<List<AffiliateSubmission>> GetAffiliateSubmissionBySubmissionIds(List<long> submissionIds, int typeId, List<long> externalStoreIds)
        {
            var result = await _affiliateSubmissionRepository
                .Filter(x => externalStoreIds.Contains(x.ExternalStoreId) &&
                            x.SubmissionType == typeId &&
                            submissionIds.Contains(x.Id))
                .Include(x => x.AffiliateOrderDetails)
                .ToListAsync();
            return result;
        }

        public async Task<AffiliateSubmission> GetAffiliateSubmissionBySubmissionId(long submissionId, long externalStoreId)
        {
            var result = await _affiliateSubmissionRepository
                .Filter(x => x.Id == submissionId)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<ExportOrderSubmissionViewModel>> GetDataExportOrderByStoreId(FilterDataExportOrderByStoreId filterDataExportOrderByStoreId, CancellationToken cancellationToken)
        {
            var dataSubmission = _affiliateSubmissionRepository.Filter(x => x.IsDeleted == false && x.SubmissionType == filterDataExportOrderByStoreId.TypeId
            && (filterDataExportOrderByStoreId.ExternalStoreIds.Count > 0 && filterDataExportOrderByStoreId.ExternalStoreIds.Contains(x.ExternalStoreId))
            && (filterDataExportOrderByStoreId.ApprovalStatus == null || x.Status == filterDataExportOrderByStoreId.ApprovalStatus)
            && (filterDataExportOrderByStoreId.FromDate == null || x.OrderCreatedDate.Date >= filterDataExportOrderByStoreId.FromDate.Value.Date) && (filterDataExportOrderByStoreId.ToDate == null || x.OrderCreatedDate.Date <= filterDataExportOrderByStoreId.ToDate.Value.Date));

            if (filterDataExportOrderByStoreId.SearchType == 0)
            {
                dataSubmission = dataSubmission.Where(x => x.OrderId.Contains(filterDataExportOrderByStoreId.SearchString));
            }

            var dataSubmissionList = await dataSubmission.ToListAsync();

            var dataSubmissionListIds = dataSubmissionList.Select(x => x.PartnerId);

            TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(filterDataExportOrderByStoreId.ClientTimeZone);

            var listAffiliateUserStore = await _affiliateUserStoreRepository.Filter(p => dataSubmissionListIds.Contains(p.Id)).ToListAsync();

            var data = (from s in dataSubmissionList
                        join o in _affiliateOrderDetailRepository.Filter(null) on s.Id equals o.SubmissionId into so
                        from o in so.DefaultIfEmpty()
                        where o.IsDeleted != true
                        select new ExportOrderSubmissionViewModel
                        {
                            OrderId = s.OrderId,
                            ProductName = o != null ? o.ItemName : "",
                            ProductId = o != null ? o.ProductId : "",
                            Price = o != null ? o.Price : 0,
                            SalePrice = o != null ? o.SalePrice : 0,
                            Quantity = o != null ? o.Quantity : 0,
                            TotalPrice = o != null ? o.TotalPrice : 0,
                            Tax = s.TaxAmount,
                            ShippingFee = s.ShippingFee,
                            DiscountAmount = s.DiscountAmount,
                            SubTotalAmount = s.SubTotalAmount,
                            TotalAmount = s.TotalAmount,
                            PaymentMethod = s.PaymentMethod,
                            OrdateDate = TimeZoneInfo.ConvertTimeFromUtc(s.OrderCreatedDate.ToUniversalTime(), userTimeZone).ToString("dd/MM/yyyy HH:mm:ss"),
                            ApprovalStatus = ((SubmissionStatusEnum)s.Status).ToString(),
                            LastModifiedDateSubmission = s.LastModifiedDate,
                            PartnerPhone = s.PartnerId != null ? listAffiliateUserStore.FirstOrDefault(x => x.Id == s.PartnerId)?.PhoneNumber : "",
                            CustomerName = s.CustomerName,
                            CustomerPhone = s.CustomerPhone,
                            CustomerAddress = s.CustomerAddress
                        })
                        .OrderByDescending(x => x.LastModifiedDateSubmission)
                        .ThenBy(x => x.ProductName)
                        .Skip((filterDataExportOrderByStoreId.PageNumber - 1) * filterDataExportOrderByStoreId.PageSize)
                        .Take(filterDataExportOrderByStoreId.PageSize)
                        .ToList();

            return data;
        }
        private void AddErrorToWorkSheet(ExcelWorksheet worksheet, int indexStart, int row, int col, string message)
        {
            worksheet.Cells[indexStart - 1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[indexStart - 1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(254, 0, 0));
            worksheet.Cells[indexStart - 1, col].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(255, 255, 255));
            worksheet.Cells[indexStart - 1, col].Style.Font.SetFromFont("Calibri", 11, true);
            worksheet.Cells[indexStart - 1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells[indexStart - 1, col].Value = "ERROR";
            worksheet.Cells[row, col].Value = message;
            worksheet.Cells[row, col].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(254, 0, 0));
        }
        public async Task<ResultImportDataViewModel> ImportSubmissionAndOrderIdFromExcel(ExcelPackage excelPackage, long externalStoreId, CancellationToken cancellationToken, TimeZoneInfo clientTimeZone, bool isFileTemplate = false)
        {
            string tempOrderId = null;
            List<AffiliateSubmission> lstSubmission = new List<AffiliateSubmission>();
            List<AffiliateSubmission> lstSubmissionExist = new List<AffiliateSubmission>();
            List<AffiliateOrderDetail> lstOrderDetail = new List<AffiliateOrderDetail>();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.End.Row;
            int colCount = worksheet.Dimension.Columns;
            List<int> lstRowSuccess = [];
            List<int> lstRowEmpty = [];
            List<int> lstNeedRemove = [];
            List<int> lstNeedAdd = [];
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {
                    var lstProduct = _affiliateProductRepository.Filter(x => x.AffiliateStoreId == externalStoreId && x.IsDeleted == false).ToList();
                    var affiliateOrderExcelMapping = new AffiliateOrderExcelMapping();
                    if (isFileTemplate == false)
                    {
                        affiliateOrderExcelMapping = new AffiliateOrderExcelMapping(_affiliateMappingRepository.Filter(x => x.AffiliateStoreId == externalStoreId && x.IsDeleted == false).ToList());
                    }
                    var listAffiliateUserStore = _affiliateUserStoreRepository.Filter(p => p.AffiliateStoreId == externalStoreId).ToList();

                    var listOrderId = new HashSet<string>();
                    for (int i = affiliateOrderExcelMapping.RowStart + 1; i <= rowCount; i++)
                    {
                        if (worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value?.ToString() != null)
                            listOrderId.Add(worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString());
                    }
                    lstSubmissionExist = _affiliateSubmissionRepository.Filter(x => listOrderId.Contains(x.OrderId) && x.ExternalStoreId == externalStoreId & !x.IsDeleted).ToList();

                    for (int i = affiliateOrderExcelMapping.RowStart + 1; i <= rowCount; i++)
                    {
                        if (_affiliateMappingServices.IsRowValidateEmpty(worksheet, affiliateOrderExcelMapping, i))
                        {
                            lstRowEmpty.Add(i);
                            continue;
                        }

                        var validate = _affiliateMappingServices.RowValidateSubmisison(worksheet, lstProduct, externalStoreId, affiliateOrderExcelMapping, i);
                        long? publisherId = null;

                        if (affiliateOrderExcelMapping.ColMappingPublisher != null)
                        {
                            string phonePartner = worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingPublisher].Value?.ToString() ?? "";

                            if (!string.IsNullOrEmpty(phonePartner))
                            {
                                var fixPhone = CommonFunction.ConvertCountryToPhoneNumber("0", phonePartner);
                                var affiliateUser = listAffiliateUserStore.Where(x => x.PhoneNumber == fixPhone).FirstOrDefault();

                                publisherId = affiliateUser?.Id;
                                if (publisherId == null)
                                {
                                    validate.Add(string.Format(GetLocalizedValue("export.orderExternalStore.errorMessageImport.notExist"),
                                                    GetLocalizedValue("export.orderExternalStore.filedName.publisherPhone")));
                                }
                            }
                        }

                        if (validate.Count > 0)
                        {
                            if (colCount == worksheet.Dimension.Columns)
                            {
                                worksheet.InsertColumn(colCount + 1, 1);
                            }
                            AddErrorToWorkSheet(worksheet, affiliateOrderExcelMapping.RowStart + 1, i, colCount + 1, string.Join(", ", validate));
                            continue;
                        }
                        else if (worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value?.ToString() != null)
                        {
                            var submissionExist = lstSubmissionExist.Where(x => x.OrderId == worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString() && x.ExternalStoreId == externalStoreId & !x.IsDeleted).FirstOrDefault();
                            if (submissionExist == null && lstSubmission.Find(x => x.OrderId == worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString()) != null)
                                submissionExist = lstSubmission.Find(x => x.OrderId == worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString());

                            if (tempOrderId != worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString())
                            {
                                tempOrderId = worksheet.Cells[i, (int)affiliateOrderExcelMapping.ColMappingOrderId].Value.ToString();

                                // Read orderId first time 
                                if (submissionExist == null)
                                {
                                    var submissionNew = _affiliateMappingServices.BuildSubmission(worksheet, externalStoreId, affiliateOrderExcelMapping, i, clientTimeZone);

                                    if (publisherId != null)
                                    {
                                        submissionNew.PartnerId = publisherId;
                                    }
                                    lstSubmission.Add(submissionNew);
                                    lstRowSuccess.Add(i);
                                }
                                // OrderId readed
                                if (submissionExist != null)
                                {

                                    var submissionUpdate = _affiliateMappingServices.BuildSubmission(worksheet, externalStoreId, affiliateOrderExcelMapping, i, clientTimeZone, submissionExist);
                                    submissionUpdate.Id = submissionExist.Id;

                                    if (publisherId != null)
                                    {
                                        submissionUpdate.PartnerId = publisherId;
                                    }
                                    lstSubmissionExist.Remove(submissionExist);
                                    lstSubmissionExist.Add(submissionUpdate);

                                    lstRowSuccess.Add(i);
                                }
                            }
                            else
                            {
                                _affiliateMappingServices.BuildSubmission(worksheet, externalStoreId, affiliateOrderExcelMapping, i, clientTimeZone, submissionExist);
                                lstRowSuccess.Add(i);
                            }
                        }
                    }

                    var lstSubmissionExistId = lstSubmissionExist.Select(x => x.Id).ToList();

                    if (lstSubmissionExistId.Count > 0)
                    {
                        // Remove current order detail of submission exist
                        var lstOrderDetailRemove = _affiliateOrderDetailRepository.Filter(x => lstSubmissionExistId.Contains(x.SubmissionId) && x.IsDeleted == false).ToList();

                        if (lstOrderDetailRemove.Count > 0)
                        {
                            lstOrderDetailRemove.ForEach(x => x.IsDeleted = true);
                            _affiliateOrderDetailRepository.UpdateRange(lstOrderDetailRemove);
                        }
                    }

                    _affiliateSubmissionRepository.AddRange(lstSubmission);
                    var orderIds = lstSubmissionExist.Select(x => x.OrderId).ToArray();
                    await UpdateTrackingIdsForSubmissionExisted(lstSubmissionExist, orderIds);

                    _affiliateSubmissionRepository.UpdateRange(lstSubmissionExist);
                    await _affiliateSubmissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                    transaction.Commit();
                    //Clear Row Success
                    lstNeedRemove.AddRange(lstRowSuccess);
                    lstNeedRemove.AddRange(lstRowEmpty);
                    lstNeedRemove = lstNeedRemove.OrderBy(x => x).ToList();
                    for (int i = lstNeedRemove.Count - 1; i >= 0; i--)
                    {
                        worksheet.DeleteRow(lstNeedRemove[i]);
                    }
                    var stream = new MemoryStream(excelPackage.GetAsByteArray());
                    string fileName = string.Format("Error", DateTime.UtcNow.ToString("ddMMyyyy_HHmmss"));
                    return await Task.FromResult(new ResultImportDataViewModel(stream.ToArray(), fileName, lstRowSuccess.Count, rowCount - affiliateOrderExcelMapping.RowStart - lstRowSuccess.Count - lstRowEmpty.Count));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateStoreCommandHandler)} : {ex.Message}");
                    throw new Exception(ex.Message);
                }
            }
        }

        private async Task UpdateTrackingIdsForSubmissionExisted(List<AffiliateSubmission> lstSubmissionExist, string[] orderIds)
        {
            var lsAffOrderTracking = await GetAffiliateOrderTrackingByOrderId(orderIds);

            if (lsAffOrderTracking.Count > 0)
            {
                foreach (var submission in lstSubmissionExist)
                {
                    if (string.IsNullOrEmpty(submission.TrackingIds))
                    {
                        submission.TrackingIds = lsAffOrderTracking.FirstOrDefault(x => x.OrderId.Equals(submission.OrderId))?.TrackingIds;
                    }
                }
            }
        }
        private async Task<List<AffiliateOrderTracking>> GetAffiliateOrderTrackingByOrderId(string[] orderIds)
        {
            if (orderIds.Length == 0) return new List<AffiliateOrderTracking>();
            var affiliateOrders = await _affiliateOrderTrackingRepository.Filter(x => !x.IsDeleted && orderIds.Contains(x.OrderId)).ToListAsync();

            return affiliateOrders;
        }

        private string GetLocalizedValue(string key, string defaultValue = "")
        {
            var localized = _localizer[key];
            return !string.IsNullOrEmpty(localized?.Value) && !localized.ResourceNotFound ? localized.Value : (!string.IsNullOrEmpty(defaultValue) ? defaultValue : key);
        }
        public async Task<long> UpdateListSubmissionAsync(List<AffiliateSubmission> submissions, CancellationToken cancellationToken)
        {
            try
            {
                submissions = submissions.OrderBy(x => x.ExternalStoreId).ToList();
                long externalStoreId = 0;
                var now = DateTime.UtcNow;
                List<AffiliateSubmission> lstAffiliateSubmissionUpdate = new List<AffiliateSubmission>();
                if (submissions.Count > 0)
                {
                    externalStoreId = submissions[0].ExternalStoreId;
                    var frequencySetting = GetFinalFrequencySetting(externalStoreId).Result;
                    foreach (var submission in submissions)
                    {
                        if (submission.ExternalStoreId != externalStoreId)
                        {
                            frequencySetting = GetFinalFrequencySetting(externalStoreId).Result;
                        }
                        if (frequencySetting != null)
                        {
                            if (submission.OrderCreatedDate < frequencySetting.StartDate)
                            {
                                continue;
                            }
                            if (now > frequencySetting.CutOffDate)
                            {
                                continue;
                            }
                        }
                        lstAffiliateSubmissionUpdate.Add(submission);
                    }
                }

                _affiliateSubmissionRepository.UpdateRange(lstAffiliateSubmissionUpdate);
                var result = await _affiliateSubmissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateListSubmissionAsync)}");
                return lstAffiliateSubmissionUpdate.Count();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateListSubmissionAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        public async Task<Tuple<bool, string>> UpdateSubmissionAsync(AffiliateSubmission submission, CancellationToken cancellationToken)
        {
            try
            {
                _affiliateSubmissionRepository.Update(submission);
                var result = await _affiliateSubmissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateSubmissionAsync)}");
                return new Tuple<bool, string>(result, result ? "successfully" : "error");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateSubmissionAsync)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrackingOrderOfPublishersViewModel>> GetPublishersByAffStoreIdAsync(GetPublishersByAffStoreIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<TrackingOrderOfPublishersViewModel>();
                if (request.IsRunCronJob != true && _affStore == null)
                {
                    return await Task.FromResult(result);
                }

                var listSubmission = await _affiliateSubmissionRepository.Filter(filter: SubmissionFilter(request), includes: [x => x.AffiliateOrderDetails.Where(x => x.IsDeleted == false)]).ToListAsync();

                var listTrackingIdForTakePlatform = new List<string>();
                var listGroupIdForTakePlatform = new List<string>();

                listSubmission?.ForEach(submission =>
                {
                    if (submission.TrackingIds != null)
                        listTrackingIdForTakePlatform.AddRange(submission.TrackingIds.Split(','));
                });

                listTrackingIdForTakePlatform = listTrackingIdForTakePlatform.Distinct().ToList();
                var listPartnerIds = _affiliatePartnerServices.GetPartnerByTrackingIds(string.Join(',', listTrackingIdForTakePlatform));
                var listLink = _affiliateLinkRepository.Filter(x => listTrackingIdForTakePlatform.Contains(x.TrackingId.ToString()), includes: [x => x.AffiliateProduct]).ToList();
                var publisherData = new List<TrackingOrderOfPublishersViewModel>();
                foreach (var item in listSubmission)
                {
                    if (item.PartnerId > 0)
                    {
                        if (request.PublisherId != null && item.PartnerId != request.PublisherId)
                        {
                            continue;
                        }

                        var indexUpdate = publisherData.FindIndex(x => x.PublisherId == item.PartnerId);

                        //If the publisherData has the publisher
                        if (indexUpdate > -1)
                        {
                            var mappedOrder = _mapper.Map<OrderDetailsOfPublisherViewModel>(item);
                            publisherData[indexUpdate].Orders.Add(mappedOrder);
                        }
                        //If the publisherData hasn't the publisher
                        else
                        {
                            var mappedOrder = _mapper.Map<OrderDetailsOfPublisherViewModel>(item);
                            var outputItem = new TrackingOrderOfPublishersViewModel()
                            {
                                PublisherId = (int)item.PartnerId,
                                Orders = [mappedOrder]
                            };
                            publisherData.Add(outputItem);
                        };
                        continue;
                    }
                    else if (item.TrackingIds != null)
                    {
                        var listProductId = item.AffiliateOrderDetails.Select(x => x.ProductId).ToList();

                        var listTrackingIdHaveProduct = listLink.Where(x => item.TrackingIds.Contains(x.TrackingId.ToString()) && x.AffiliateProduct != null && listProductId.Contains(x.AffiliateProduct.RefProductId.ToString())).Select(x => x.TrackingId).ToList();
                        Guid trackingId = new Guid();

                        //If the TrackingId has the Product
                        if (listTrackingIdHaveProduct.Count > 0)
                        {
                            if (request.TrackingPrioritize == TrackingPrioritizeEnum.LAST)
                            {
                                trackingId = _affiliateClickTrackingRepository.Filter(x => listTrackingIdHaveProduct.Contains(x.TrackingId) && x.CreatedDate <= item.CreatedDate).OrderBy(x => x.CreatedDate).Select(x => x.TrackingId).LastOrDefault();
                            }
                            else if (request.TrackingPrioritize == TrackingPrioritizeEnum.FIRST)
                            {
                                trackingId = _affiliateClickTrackingRepository.Filter(x => listTrackingIdHaveProduct.Contains(x.TrackingId) && x.CreatedDate <= item.CreatedDate).OrderBy(x => x.CreatedDate).Select(x => x.TrackingId).FirstOrDefault();
                            }
                        }
                        //If the TrackingId hasn't the Product
                        else
                        {
                            var listTrackingId = listLink.Where(x => item.TrackingIds.Contains(x.TrackingId.ToString()) && (x.AffiliateProduct == null || !listProductId.Contains(x.AffiliateProduct.RefProductId.ToString()))).Select(x => x.TrackingId).ToList();
                            if (request.TrackingPrioritize == TrackingPrioritizeEnum.LAST)
                            {
                                trackingId = _affiliateClickTrackingRepository.Filter(x => listTrackingId.Contains(x.TrackingId) && x.CreatedDate <= item.CreatedDate).OrderBy(x => x.CreatedDate).Select(x => x.TrackingId).LastOrDefault();
                            }
                            else if (request.TrackingPrioritize == TrackingPrioritizeEnum.FIRST)
                            {
                                trackingId = _affiliateClickTrackingRepository.Filter(x => listTrackingId.Contains(x.TrackingId) && x.CreatedDate <= item.CreatedDate).OrderBy(x => x.CreatedDate).Select(x => x.TrackingId).FirstOrDefault();
                            }

                        }

                        if (trackingId == Guid.Empty)
                        {
                            continue;
                        }
                        if (request.PublisherId == null || listPartnerIds[trackingId] == request.PublisherId)
                        {
                            var indexUpdate = publisherData.FindIndex(x => x.PublisherId == listPartnerIds[trackingId]);
                            //If the publisherData has the publisher
                            if (indexUpdate > -1)
                            {
                                try
                                {
                                    var mappedOrder = _mapper.Map<OrderDetailsOfPublisherViewModel>(item);
                                    publisherData[indexUpdate].Orders.Add(mappedOrder);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message, ex);
                                }
                            }

                            //If the publisherData hasn't the publisher
                            else
                            {
                                try
                                {
                                    var mappedOrder = _mapper.Map<OrderDetailsOfPublisherViewModel>(item);
                                    var outputItem = new TrackingOrderOfPublishersViewModel()
                                    {
                                        PublisherId = listPartnerIds[trackingId],
                                        Orders = [mappedOrder]
                                    };
                                    publisherData.Add(outputItem);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message, ex);
                                }
                            };
                        }

                    }
                }

                SortData(publisherData);

                return await Task.FromResult(publisherData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private string TakeFistOrLastTrackingId(AffiliateSubmission affiliateSubmission, GetPublishersByAffStoreIdQuery request)
        {
            var listTrackingId = affiliateSubmission.TrackingIds.Split(",").ToList();
            if (request.TrackingPrioritize == TrackingPrioritizeEnum.LAST)
            {
                listTrackingId = new List<string>()
                {
                    listTrackingId.LastOrDefault()
                };
            }
            else if (request.TrackingPrioritize == TrackingPrioritizeEnum.FIRST)
            {
                listTrackingId = new List<string>()
                {
                    listTrackingId.FirstOrDefault()
                };
            }
            return listTrackingId.Count > 0 ? string.Join(',', listTrackingId) : string.Empty;
        }

        private void SortData(List<TrackingOrderOfPublishersViewModel> publisherData)
        {
            publisherData = publisherData.OrderBy(x => x.PublisherId).ToList();

            foreach (var publisher in publisherData)
            {
                publisher.Orders = publisher.Orders.OrderByDescending(x => x.CreatedDate).ToList();
                foreach (var order in publisher.Orders)
                {
                    order.Products = order.Products.OrderByDescending(x => x.ProductId).ToList();
                }
            }
        }

        private Expression<Func<AffiliateSubmission, bool>> SubmissionFilter(GetPublishersByAffStoreIdQuery request)
        {
            Expression<Func<AffiliateSubmission, bool>> filter = submission => submission.ExternalStoreId == request.ExternalStoreId && !submission.IsDeleted;

            if (request.StartDate != null && request.EndDate != null)
            {
                return filter.And(x => x.OrderCreatedDate.Date >= request.StartDate.Value.Date && x.OrderCreatedDate.Date <= request.EndDate.Value.Date);
            }
            else if (request.StartDate != null && request.EndDate == null)
            {
                return filter.And(x => x.OrderCreatedDate.Date >= request.StartDate.Value.Date);
            }
            else if (request.StartDate == null && request.EndDate != null)
            {
                return filter.And(x => x.OrderCreatedDate.Date <= request.EndDate.Value.Date);
            }
            else
            {
                return filter;
            }
        }

        public async Task CreateAffiliateSubmissionHistory(long submissionId, HistoryMessageTemplate jsonActionHistory = null, string description = "")
        {
            try
            {
                var url = $"/netservice/api/v1/common-history/history-node-create";
                var token = string.Empty;
                var authorToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (authorToken != null)
                {
                    token = authorToken?.Split(" ").Last();
                }

                var body = new
                {
                    Type = CommonHistoryType.ORDER_DETAIL,
                    ObjectId = submissionId,
                    JsonActionHistory = JsonConvert.SerializeObject(jsonActionHistory != null ? jsonActionHistory : string.Empty),
                    Description = description
                };

                await _httpClientHelper.SendServiceApiPostAsync<Object>(
                              _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                              url, ApiNameConstants.HISTORY_SERVICE, body, token);

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(CreateAffiliateSubmissionHistory)} : {ex.Message}");
            }
        }

        private async Task<FinalCommissionFrequencySettingResponse> GetFinalFrequencySetting(long externalStoreId)
        {
            try
            {
                var url = $"/netservice/api/v1/commission/get-final-frequency-setting/{externalStoreId}";
                var token = string.Empty;
                var authorToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (authorToken != null)
                {
                    token = authorToken?.Split(" ").Last();
                }

                var result = await _httpClientHelper.SendServiceApiGetAsync<GenericResponse<FinalCommissionFrequencySettingResponse>>(
                              _configuration.GetSectionValueWithEnvironment("ApiBaseUrl"),
                              url, ApiNameConstants.COMMISSION_SERVICE);
                return result?.Data;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error {nameof(GetFinalFrequencySetting)} : {ex.Message}");
                throw;
            }
        }

        public Tuple<bool, string> GetCommissionApplyStatus(AffiliateSubmission submission)
        {
            var frequencySetting = GetFinalFrequencySetting(submission.ExternalStoreId)?.Result;
            var now = DateTime.UtcNow;
            if (frequencySetting != null)
            {
                if (submission.OrderCreatedDate < frequencySetting.StartDate)
                {
                    return new Tuple<bool, string>(true, "submission_calculated");
                }
                if (now > frequencySetting.CutOffDate)
                {
                    return new Tuple<bool, string>(true, "submission_calculated");
                }
            }
            return new Tuple<bool, string>(false, string.Empty);
        }

    }
}
