using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Common.Models;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdateStatusSubmissionCommandHandler : IRequestHandler<UpdateStatusSubmissionCommand, Tuple<bool, string>>
    {
        private readonly ILogger<UpdateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        public UpdateStatusSubmissionCommandHandler(ILogger<UpdateAffiliateStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<Tuple<bool, string>> Handle(UpdateStatusSubmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var submission = await _affiliateSubmissionServices.GetAffiliateSubmissionBySubmissionId(request.SubmissionId, (int)request.SubmissionType);
                if (submission == null)
                {
                    throw new Exception("Submission not exist");
                }

                var commissionApplyStatus = _affiliateSubmissionServices.GetCommissionApplyStatus(submission);
                if (commissionApplyStatus.Item1)
                {
                    Log.Logger.Information($"DONE {nameof(UpdateStatusSubmissionCommand)}");
                    return new Tuple<bool, string>(false, commissionApplyStatus.Item2);
                }

                if (new[] { SubmissionStatusEnum.APPROVED, SubmissionStatusEnum.REJECTED }.Contains(request.SubmissionStatus))
                {
                    submission.Status = (int)request.SubmissionStatus;
                    submission.LastModifiedDate = DateTime.UtcNow;
                    var messageTemplate = "";
                    switch (submission.Status)
                    {
                        case (int)SubmissionStatusEnum.APPROVED:
                            messageTemplate = "page.affiliate.order.externalStore.approved";
                            break;
                        case (int)SubmissionStatusEnum.REJECTED:
                            messageTemplate = "page.affiliate.order.externalStore.reject";
                            break;
                    }
                    if (!string.IsNullOrEmpty(messageTemplate)) await _affiliateSubmissionServices.CreateAffiliateSubmissionHistory(submission.Id, new HistoryMessageTemplate()
                    {
                        MessageTemplate = messageTemplate,
                        Params = []
                    }, "");
                }
                if (request.SubmissionStatus == SubmissionStatusEnum.DELETED)
                {
                    var affOrderDetails = submission.AffiliateOrderDetails;
                    foreach (var affOrderDetail in affOrderDetails)
                    {
                        affOrderDetail.IsDeleted = true;
                        affOrderDetail.LastModifiedDate = DateTime.UtcNow;
                    }
                    submission.AffiliateOrderDetails = affOrderDetails;
                    submission.IsDeleted = true;
                    submission.LastModifiedDate = DateTime.UtcNow;
                }

                var result = await _affiliateSubmissionServices.UpdateSubmissionAsync(submission, cancellationToken);
                Log.Logger.Information($"DONE {nameof(UpdateStatusSubmissionCommand)}");
                return result;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(UpdateStatusSubmissionCommand)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
