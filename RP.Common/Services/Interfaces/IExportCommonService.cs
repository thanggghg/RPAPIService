using RP.Common.Models.Responses;
using RP.Common.Queries;

namespace RP.Common.Services.Interfaces
{
    public interface IExportCommonService<T> where T : class
    {
        Task<ExportCommonQueryResponse> ProcessAsync(ExportCommonQuery<T> exportQuery);
    }
}
