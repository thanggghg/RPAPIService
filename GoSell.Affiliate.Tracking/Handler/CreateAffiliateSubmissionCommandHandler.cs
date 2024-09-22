using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateAffiliateSubmissionCommandHandler : IRequestHandler<CreateAffiliateSubmissionCommand, (int, string)>
    {
        private readonly ILogger<CreateAffiliateSubmissionCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        private readonly AffiliateContext _affiliateContext;
        public CreateAffiliateSubmissionCommandHandler(ILogger<CreateAffiliateSubmissionCommandHandler> logger,
                                                  IMapper mapper,
                                                  IAffiliateStoreServices affiliateStoreServices,
                                                  IAffiliateSubmissionServices affiliateSubmissionServices,
                                                  AffiliateContext affiliateContext)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateSubmissionServices = affiliateSubmissionServices;
            _affiliateContext = affiliateContext;
        }

        public async Task<(int, string)> Handle(CreateAffiliateSubmissionCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {
                    var affiliateStore = _affiliateStoreServices.GetStoreByApiKey(request.ApiKey);
                    if (string.IsNullOrEmpty(request.ApiKey) || affiliateStore == null)
                    {
                        return ((int)SubmissionCodeEnum.BAD_REQUEST, nameof(SubmissionCodeEnum.INVALID_API_KEY));
                    }

                    AffiliateSubmission affiliateSubmission = _mapper.Map<AffiliateSubmission>(request);
                    affiliateSubmission.ExternalStoreId = affiliateStore.Id;
                    affiliateSubmission.UpdateCreatedBy("Client");
                    affiliateSubmission.LastModifiedBy = affiliateSubmission.CreatedBy;
                    affiliateSubmission.LastModifiedDate = affiliateSubmission.CreatedDate;
                    List<AffiliateOrderDetail> affiliateOrderDetails = _mapper.Map<List<AffiliateOrderDetail>>(request);
                    affiliateOrderDetails.ForEach(x =>
                    {
                        x.SubmissionId = affiliateSubmission.Id;
                        x.CreatedDate = affiliateSubmission.CreatedDate;
                        x.CreatedBy = affiliateSubmission.CreatedBy;
                        x.LastModifiedDate = affiliateSubmission.CreatedDate;
                        x.LastModifiedBy = affiliateSubmission.CreatedBy;
                    });

                    var result = await _affiliateSubmissionServices.CreateAffiliateSubmission(affiliateSubmission, affiliateOrderDetails, cancellationToken);

                    if (result != nameof(SubmissionCodeEnum.SUCCESS))
                    {
                        transaction.Rollback();
                    }
                    else
                    {
                        transaction.Commit();
                    }

                    Log.Logger.Information($"DONE {nameof(CreateAffiliateSubmissionCommandHandler)}");
                    return ResultOutput(result);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateSubmissionCommandHandler)} : {ex.Message}");
                    throw new Exception(ex.Message);
                }
            }
        }

        private (int, string) ResultOutput(string result)
        {
            switch (result)
            {
                case nameof(SubmissionCodeEnum.EXSITED_CONVERSION):
                    return ((int)SubmissionCodeEnum.BAD_REQUEST, nameof(SubmissionCodeEnum.EXSITED_CONVERSION));
                case nameof(SubmissionCodeEnum.ORDER_ID_EXISTED):
                    return ((int)SubmissionCodeEnum.BAD_REQUEST, nameof(SubmissionCodeEnum.ORDER_ID_EXISTED));
                case nameof(SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR):
                    return ((int)SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR, nameof(SubmissionCodeEnum.HTTP_CLIENT_INTERNAL_SERVER_ERROR));
                default:
                    return ((int)SubmissionCodeEnum.SUCCESS, "");
            }
        }
    }
}
