using RP.Common.Models.Responses;
using RP.Common.Queries;
using RP.Common.Services.Interfaces;
using MediatR;
using Serilog;

namespace RP.Common.Handlers
{
    public class ExportCommonHandler<T> : IRequestHandler<ExportCommonQuery<T>, ExportCommonQueryResponse> where T : class
    {
        private readonly IExportCommonService<T> _exportService;

        public ExportCommonHandler(IExportCommonService<T> exportService)
        {
            _exportService = exportService;
        }

        public async Task<ExportCommonQueryResponse> Handle(ExportCommonQuery<T> request, CancellationToken cancellationToken)
        {
            try
            {
                return await _exportService.ProcessAsync(request);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"ExportHandler: {ex.Message}");
                throw;
            }
        }
    }
}
