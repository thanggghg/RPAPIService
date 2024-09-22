using System.Runtime.Serialization;

namespace GoSell.Affiliate.Tracking.ViewModels
{
    public class CreateAffiliateMappingViewModel
    {
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public string MappingKey { get; set; }
        [DataMember]
        public int ColumnIndex { get; set; }
        [DataMember]
        public int RowIndex { get; set; }
    }
}
