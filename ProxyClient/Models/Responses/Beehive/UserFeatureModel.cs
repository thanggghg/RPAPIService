namespace ProxyClient.Models.Responses.Beehive
{
    public class UserFeatureModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ExpiredId { get; set; }
        public long PackageId { get; set; }
        public long RegisterPackageDate { get; set; }
        public long ExpiredPackageDate { get; set; }
        public PlanPaidStatus PackagePay { get; set; }
    }

    public enum PlanPaidStatus
    {
        /**
         * Trial plan paid status.
         */
        TRIAL,
        /**
         * Paid plan paid status.
         */
        PAID,
        /**
         * Free plan paid status.
         */
        FREE,
        FREE_TRIAL
    }
}
