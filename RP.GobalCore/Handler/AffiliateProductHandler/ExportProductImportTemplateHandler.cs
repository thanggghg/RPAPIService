using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Queries.AffiliateProduct;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace RP.Affiliate.Tracking.Handler.AffiliateProductHandler
{
    public class ExportProductImportTemplateHandler : IRequestHandler<ExportProductImportTemplateQuery, byte[]>
    {
        private readonly IAffiliateProductFunctions _affiliateProductFunctions;
        private readonly ILogger<ExportProductImportTemplateHandler> _logger;
        private readonly IWebHostEnvironment _environment;
        public ExportProductImportTemplateHandler(IAffiliateProductFunctions affiliateProductFunctions,
            ILogger<ExportProductImportTemplateHandler> logger,
            IWebHostEnvironment environment
            )
        {
            _logger = logger;
            _affiliateProductFunctions = affiliateProductFunctions;
            _environment = environment;
        }

        public async Task<byte[]> Handle(ExportProductImportTemplateQuery request, CancellationToken cancellationToken)
        {
            return await _affiliateProductFunctions.ExportProductImportTemplate(request);
        }
    }
}
