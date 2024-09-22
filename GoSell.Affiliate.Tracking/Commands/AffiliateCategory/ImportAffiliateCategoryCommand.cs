using System.Runtime.Serialization;
using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GoSell.Affiliate.Tracking.Commands.AffiliateCategory
{
    public class ImportAffiliateCategoryCommand(IFormFile file, long affiliateStoreId, string langKey) : IRequest<ImportAffiliateCategoryResponse>
    {
        [DataMember]
        public virtual long AffiliateStoreId { get; set; } = affiliateStoreId;

        [DataMember]
        public virtual IFormFile File { get; set; } = file;

        [DataMember]
        public virtual string LangKey { get; set; } = langKey;
    }
}
