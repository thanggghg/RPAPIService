using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Queries.AffiliateCategory;
using GoSell.Affiliate.Tracking.Queries.AffiliateProduct;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Handler.AffiliateCategoryHandler
{
    public class ExportCategoryImportTemplateHandler : IRequestHandler<ExportCategoryImportTemplateQuery, byte[]>
    {
        private readonly IAffiliateCategoryFunctions _affiliateCategoryFunctions;
        private readonly ILogger<ExportCategoryImportTemplateHandler> _logger;
        private readonly IWebHostEnvironment _environment;
        public ExportCategoryImportTemplateHandler(IAffiliateCategoryFunctions affiliateCategoryFunctions,
            ILogger<ExportCategoryImportTemplateHandler> logger,
            IWebHostEnvironment environment
            )
        {
            _logger = logger;
            _affiliateCategoryFunctions = affiliateCategoryFunctions;
            _environment = environment;
        }

        public async Task<byte[]> Handle(ExportCategoryImportTemplateQuery request, CancellationToken cancellationToken)
        {
            return await _affiliateCategoryFunctions.ExportCategoryImportTemplate(request);
        }
    }
}
