using GoSell.Common.Enums;
using GoSell.Common.Models.Requests;
using GoSell.Common.Models.Responses;
using MediatR;

namespace GoSell.Common.Queries
{
    public class ExportCommonQuery<T> : IRequest<ExportCommonQueryResponse> where T : class
    {
        public ExportCommonQuery(ExportCommonRequest exportRequest, ExportCommonServiceType exportServiceType, long storeId, T additionData = null)
        {
            ExportRequest = exportRequest;
            ExportType = exportServiceType;
            StoreId = storeId;
            AdditionData = additionData;
        }

        public ExportCommonServiceType ExportType { get; set; }

        public ExportCommonRequest ExportRequest { get; set; }

        public long StoreId { get; set; }

        public T AdditionData { get; set;}
    }
}
