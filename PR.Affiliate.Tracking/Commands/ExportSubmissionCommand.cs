using GoSell.Affiliate.Tracking.ViewModels;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class ExportSubmissionCommand : IRequest<FileDataViewModel>
    {
        public long? ExternalStoreId { get; set; }
        public int TypeId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int? SearchType { get; set; }
        public string SearchString { get; set; }
        public int? PaymentMethod { get; set; }
        public int? ApprovalStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Langkey { get; set; }
        public bool? IsStoreDeleted { get; set; }
        public string ClientTimeZone { get; set; }

        public ExportSubmissionCommand(long? externalStoreId, int typeId, int pageSize, int pageNumber,
            string searchString, int? searchType, int? paymentMethod, int? approvalStatus, DateTime? fromdate, DateTime? toDate, string langkey, bool? isStoreDeleted, string clientTimeZone)
        {
            ExternalStoreId = externalStoreId;
            TypeId = typeId;
            PageSize = pageSize;
            PageNumber = pageNumber;
            SearchString = searchString;
            SearchType = searchType;
            PaymentMethod = paymentMethod;
            ApprovalStatus = approvalStatus;
            FromDate = fromdate;
            ToDate = toDate;
            Langkey = langkey;
            IsStoreDeleted = isStoreDeleted;
            ClientTimeZone = clientTimeZone;
        }
    }
}
