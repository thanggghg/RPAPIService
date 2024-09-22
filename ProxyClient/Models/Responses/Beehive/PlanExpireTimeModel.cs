namespace ProxyClient.Models.Responses.Beehive
{
    public class PlanExpireTimeModel
    {
        public UserFeatureModel UserFeature { get; set; }
        public string PackageName { get; set; }
        public string HasOpenOrderRequest { get; set; }
        public List<string> FeatureCodes { get; set; }
    }
}
