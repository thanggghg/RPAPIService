using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateAffiliateStoreCommand : IRequest<long>
    {
        [DataMember]
        public string Logo { get; set; }
        [DataMember]
        public bool AllowPublisherRegister { get; set; } = false;
        [DataMember]
        public bool AutoApproved { get; set; } = false;
        [DataMember]
        public int CookieDurationDay { get; set; } = 30;
        [DataMember]
        public string ApiKey { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public long GoSellStoreId { get; set; }
        [DataMember]
        public long ColorId { get; set; }
        [DataMember]
        public long BusinessId { get; set; }
        [DataMember]
        public long? CurrencyId { get; set; }
    }
}
