using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commons.Constants;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Handler;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.Utils;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
using Serilog;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliatePartnerServices : IAffiliatePartnerServices
    {
        public ILogger<AffiliatePartnerServices> Logger { get; }
        private readonly IAffiliateRepository<AffiliateSubmission> _affiliateSubmissionRepository;
        private readonly IAffiliateRepository<AffiliateTrackingManagement> _affiliateTrackingManagementRepository;

        public AffiliatePartnerServices(
            ILogger<AffiliatePartnerServices> logger,
            IAffiliateRepository<AffiliateSubmission> affiliateSubmissionRepository,
            IAffiliateRepository<AffiliateTrackingManagement> affiliateTrackingManagementRepository
        )
        {
            Logger = logger;
            _affiliateSubmissionRepository = affiliateSubmissionRepository;
            _affiliateTrackingManagementRepository = affiliateTrackingManagementRepository;
        }

        public IQueryable<long> GetPartnerIdByTrackingIds(string trackingIds)
        {
            try
            {
                var temp = _affiliateTrackingManagementRepository.Filter(x => trackingIds.Contains(x.TrackingId.ToString())).ToList();
                var partnerIds = _affiliateTrackingManagementRepository.Filter(x => trackingIds.Contains(x.TrackingId.ToString())).OrderBy(x => x.LastModifiedDate).Select(x => x.PartnerId);
                return partnerIds;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPartnerByTrackingIds)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public Dictionary<Guid, long> GetPartnerByTrackingIds(string trackingIds)
        {
            try
            {
                var temp = _affiliateTrackingManagementRepository.Filter(x => trackingIds.Contains(x.TrackingId.ToString())).ToList();
                var partnerIds = _affiliateTrackingManagementRepository.Filter(x => trackingIds.Contains(x.TrackingId.ToString())).OrderBy(x => x.LastModifiedDate).Select(x => new { x.TrackingId, x.PartnerId }).Distinct().ToDictionary(x => x.TrackingId, x => x.PartnerId);
                return partnerIds;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(GetPartnerByTrackingIds)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
