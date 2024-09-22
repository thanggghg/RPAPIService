using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateProduct
{
    public class ImportAffiliateProductCommand(IFormFile file, string langKey, long affiliateStoreId, long storeId) : IRequest<ImportAffiliateProductResult>
    {
        [DataMember]
        public virtual IFormFile File { get; set; } = file;

        [DataMember]
        public virtual string LangKey { get; set; } = langKey;


        [DataMember]
        public virtual long AffiliateStoreId { get; set; } = affiliateStoreId;

        [DataMember]
        public virtual long StoreId { get; set; } = storeId;
    }
}
