using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateProduct
{
    public class ExportProductImportTemplateQuery : IRequest<byte[]>
    {
        public string LangKey { get; set; }
    }
}
