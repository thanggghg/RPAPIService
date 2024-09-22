using System.Runtime.Serialization;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    [DataContract]
    public class CreateThemeCommand : IRequest<bool>
    {
        [DataMember]
        public long StoreId { get; set; }
        [DataMember]
        public long ColorId { get; set; }
        [DataMember]
        public string Logo { get; set; }
        public string CoverImage { get; set; }
        [DataMember]
        public bool IsPublished { get; set; } = false;
        [DataMember]
        public long BusinessId { get; set; }
    }

    [DataContract]
    public class UpdateThemeCommand : CreateThemeCommand, IRequest<bool>
    {
        [DataMember]
        public long Id { get; set; }
    }

    [DataContract]
    public class PublishThemeCommand : IRequest<bool>
    {
        [DataMember]
        public long Id { get; set; }
    }

    [DataContract]
    public class DeleteThemeCommand : IRequest<bool>
    {
        [DataMember]
        public long Id { get; set; }
    }
}
