using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Common.Models;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdatePartnerSubmissionCommandHandler : IRequestHandler<UpdatePartnerSubmissionCommand, Tuple<bool, string>>
    {
        private readonly ILogger<UpdateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        public UpdatePartnerSubmissionCommandHandler(ILogger<UpdateAffiliateStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<Tuple<bool, string>> Handle(UpdatePartnerSubmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var submission = await _affiliateSubmissionServices.GetAffiliateSubmissionBySubmissionId(request.SubmissionId, request.ExternalStoreId);
                if (submission == null)
                {
                    throw new Exception("Submissions not exist");
                }
                submission.PartnerId = request.PartnerId;
                submission.LastModifiedDate = DateTime.UtcNow;

                var commissionApplyStatus = _affiliateSubmissionServices.GetCommissionApplyStatus(submission);
                if (commissionApplyStatus.Item1)
                {
                    Log.Logger.Information($"DONE {nameof(UpdateStatusSubmissionCommand)}");
                    return new Tuple<bool, string>(false, commissionApplyStatus.Item2);
                }

                var result = await _affiliateSubmissionServices.UpdateSubmissionAsync(submission, cancellationToken); 
                var historyParam = !string.IsNullOrEmpty(request.PartnerFullName) ? request.PartnerFullName : request.PartnerPhoneNumber;
                var historyTemplate = "";
                if (!string.IsNullOrEmpty(historyParam))
                {
                    historyTemplate = "page.affiliate.order.externalStore.assignTo";
                } else
                {
                    historyTemplate = "page.affiliate.order.externalStore.removedAssign";

                }
                await _affiliateSubmissionServices.CreateAffiliateSubmissionHistory(submission.Id, new HistoryMessageTemplate()
                {
                    MessageTemplate = historyTemplate,
                    Params = [ historyParam ]
                }, "");
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
