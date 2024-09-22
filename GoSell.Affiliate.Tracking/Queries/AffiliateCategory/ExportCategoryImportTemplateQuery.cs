using MediatR;

namespace GoSell.Affiliate.Tracking.Queries.AffiliateCategory
{
    public class ExportCategoryImportTemplateQuery : IRequest<byte[]>
    {
        public string LangKey { get; set; }
    }
}
