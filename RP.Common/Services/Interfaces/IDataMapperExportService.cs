using RP.Common.Models.Requests;
using RP.Common.Queries;

namespace RP.Common.Services.Interfaces
{
    public interface IDataMapperExportService<T> where T : class
    {
        Task<InitializeExportCommonData> GetExportDataAsync(ExportCommonQuery<T> exportQuery);
    }
}
