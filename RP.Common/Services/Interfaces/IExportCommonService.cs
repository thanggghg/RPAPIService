using GoSell.Common.Models.Responses;
using GoSell.Common.Queries;

namespace GoSell.Common.Services.Interfaces
{
    public interface IExportCommonService<T> where T : class
    {
        Task<ExportCommonQueryResponse> ProcessAsync(ExportCommonQuery<T> exportQuery);
    }
}
