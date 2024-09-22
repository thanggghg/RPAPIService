using System;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
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
    public class ImportSubmissionByTemplateCommandHandler : IRequestHandler<ImportSubmissionByFileCommand, ResultImportDataViewModel>
    {
        private readonly ILogger<GetAllAffiliateBusinessQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IStringLocalizer<ExportSubmissionCommandHandler> _localizer;
        private readonly IBaseApi _baseApi;

        public ImportSubmissionByTemplateCommandHandler(ILogger<GetAllAffiliateBusinessQueryHandler> logger,
                                           IMapper mapper,
                                           IBaseApi baseApi,
                                           IAffiliateSubmissionServices affiliateSubmissionServices,
                                           IAffiliateStoreServices affiliateStoreServices,
                                           IWebHostEnvironment hostingEnvironment,
                                           IStringLocalizer<ExportSubmissionCommandHandler> localizer)
        {
            _logger = logger;
            _mapper = mapper;
            _baseApi = baseApi;
            _affiliateSubmissionServices = affiliateSubmissionServices;
            _affiliateStoreServices = affiliateStoreServices;
            _hostingEnvironment = hostingEnvironment;
            _localizer = localizer;
        }

        public async Task<ResultImportDataViewModel> Handle(ImportSubmissionByFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var externalStoreIds = _affiliateStoreServices.GetAllAffiliateStoreByGsId(_baseApi.User.StoreId).Result.Where(x => !x.IsDeleted).ToList();
                    if (externalStoreIds.FindIndex(x => x.Id == request.AffiliateStoreId) < 0)
                    {
                        throw new Exception("Store is not exist");
                    }

                    await request.File.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    using (ExcelPackage package = new ExcelPackage(memoryStream))
                    {
                        TimeZoneInfo clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById(request.ClientTimeZone);
                        return await _affiliateSubmissionServices.ImportSubmissionAndOrderIdFromExcel(package, request.AffiliateStoreId, cancellationToken, clientTimeZone, request.IsFileTemplate);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetAllAffiliateBusinessQueryHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
