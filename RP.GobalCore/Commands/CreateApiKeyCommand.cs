using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateApiKeyCommand : IRequest<string>
    {
        [DataMember]
        public long StoreId { get; set; }
    }
}
