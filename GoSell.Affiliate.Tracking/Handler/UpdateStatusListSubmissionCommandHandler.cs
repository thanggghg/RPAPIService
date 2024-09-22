using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdateStatusListSubmissionCommandHandler : IRequestHandler<UpdateStatusListSubmissionCommand, long>
    {
        private readonly ILogger<UpdateAffiliateStoreCommandHandler> _logger;
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateSubmissionServices _affiliateSubmissionServices;
        public UpdateStatusListSubmissionCommandHandler(ILogger<UpdateAffiliateStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateSubmissionServices affiliateSubmissionServices)
        {
            _logger = logger;
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateSubmissionServices = affiliateSubmissionServices;
        }

        public async Task<long> Handle(UpdateStatusListSubmissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var submissions = await _affiliateSubmissionServices.GetAffiliateSubmissionBySubmissionIds(request.SubmissionIds, (int)request.SubmissionType, request.ExternalStoreIds);
                if (submissions == null || submissions.Count <= 0)
                {
                    throw new Exception("Submissions not exist");
                }
                foreach (var submission in submissions)
                {
                    if (new[] { SubmissionStatusEnum.APPROVED, SubmissionStatusEnum.REJECTED }.Contains(request.SubmissionStatus))
                    {
                        submission.Status = (int)request.SubmissionStatus;
                        submission.LastModifiedDate = DateTime.UtcNow;
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
                }

                var result = await _affiliateSubmissionServices.UpdateListSubmissionAsync(submissions, cancellationToken);
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
