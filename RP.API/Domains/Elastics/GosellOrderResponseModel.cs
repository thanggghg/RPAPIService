namespace GoSell.API.Domains.Elastics
{
    public abstract class AnalysisResponseModel
    {
        public object Payload { get; set; }
        public List<object> Data { get; set; }
        public int Totals { get; set; } = 0;
        
    }
    public class SalePerformanceModel
    {
        public string Key { get; set; } = string.Empty;
        public double Volumes { get; set; } = 0;
        public double Values { get; set; } = 0;
    }
    public class SalePerformanceResponseModel: AnalysisResponseModel
    {
        public new List<SalePerformanceModel> Data {  get; set; }
    }
}
