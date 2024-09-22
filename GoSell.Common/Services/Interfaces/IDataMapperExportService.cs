using GoSell.Common.Models.Requests;
using GoSell.Common.Queries;

namespace GoSell.Common.Services.Interfaces
{
    public interface IDataMapperExportService<T> where T : class
    {
        Task<InitializeExportCommonData> GetExportDataAsync(ExportCommonQuery<T> exportQuery);
    }
}
