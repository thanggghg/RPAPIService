using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class UpdateAffiliateStoreCommand : IRequest<bool>
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Logo { get; set; }
        [DataMember]
        public bool AllowPublisherRegister { get; set; } = false;
        [DataMember]
        public bool AutoApproved { get; set; } = false;
        [DataMember]
        public int CookieDurationDay { get; set; } = 5;
        [DataMember]
        public string ApiKey { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public bool AllowGetOrderTrackingUrl { get; set; }
        [DataMember]
        public bool AllowGetOrderTrackingCode { get; set; }
        [DataMember]
        public string KeyWordByUrl { get; set; }
        [DataMember]
        public string KeyWordByCode { get; set; }
        [DataMember]
        public long? CurrencyId { get; set; }

    }
}
