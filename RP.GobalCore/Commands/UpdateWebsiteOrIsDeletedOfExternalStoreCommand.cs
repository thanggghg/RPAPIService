using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class UpdateWebsiteOrIsDeletedOfExternalStoreCommand : IRequest<bool>
    {
        public long ExternalStoreId { get; set; }
        public string Website { get; set; }
        public bool IsDeleted { get; set; } = false;
        public UpdateWebsiteOrIsDeletedOfExternalStoreCommand() { }
    }
}
