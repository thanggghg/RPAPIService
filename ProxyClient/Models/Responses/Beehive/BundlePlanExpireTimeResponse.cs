namespace ProxyClient.Models.Responses.Beehive
{
    public class BundlePlanExpireTimeResponse
    {
        public List<PlanExpireTimeResponse> PlanExpireTimeResponses { get; set; }
        public BundlePackageExpiredResponse BundlePackageExpiredResponse { get; set; }
        public BundlePlanExpireTimeResponse()
        {
            PlanExpireTimeResponses = new List<PlanExpireTimeResponse>();
            BundlePackageExpiredResponse = new BundlePackageExpiredResponse();
        }
        public BundlePlanExpireTimeResponse(List<PlanExpireTimeResponse> planExpireTimeResponses, BundlePackageExpiredResponse bundlePackageExpiredResponse)
        {
            PlanExpireTimeResponses = planExpireTimeResponses;
            BundlePackageExpiredResponse = bundlePackageExpiredResponse;
        }
    }
    public class BundlePackageExpiredResponse
    {
        public long BundleExpiredPackageDate { get; set; }
        public string BundlePackagePlanName { get; set; }
        public string BundlePackagePlanCode { get; set; }

        public BundlePackageExpiredResponse() { }

        public BundlePackageExpiredResponse(long bundleExpiredPackageDate, string bundlePackagePlanName, string bundlePackagePlanCode)
        {
            BundleExpiredPackageDate = bundleExpiredPackageDate;
            BundlePackagePlanName = bundlePackagePlanName;
            BundlePackagePlanCode = bundlePackagePlanCode;
        }
    }
    public class PlanExpireTimeResponse
    {
        public UserFeatureResponse UserFeature { get; set; }
        public string PackageName { get; set; }
        public bool HasOpenOrderRequest { get; set; }
        public List<string> FeatureCodes { get; set; }

        public PlanExpireTimeResponse()
        {
            FeatureCodes = new List<string>();
        }

        public PlanExpireTimeResponse(UserFeatureResponse userFeature, string packageName, bool hasOpenOrderRequest, List<string> featureCodes)
        {
            UserFeature = userFeature;
            PackageName = packageName;
            HasOpenOrderRequest = hasOpenOrderRequest;
            FeatureCodes = featureCodes;
        }
    }

    public class UserFeatureResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ExpiredId { get; set; }
        public long PackageId { get; set; }
        public long RegisterPackageDate { get; set; }
        public long ExpiredPackageDate { get; set; }
        public PlanPaidStatus PackagePay { get; set; }

        public UserFeatureResponse()
        {
            // Default constructor
        }

        public UserFeatureResponse(long id, long userId, long expiredId, long packageId, long registerPackageDate, long expiredPackageDate, PlanPaidStatus packagePay)
        {
            Id = id;
            UserId = userId;
            ExpiredId = expiredId;
            PackageId = packageId;
            RegisterPackageDate = registerPackageDate;
            ExpiredPackageDate = expiredPackageDate;
            PackagePay = packagePay;
        }
    }
}
