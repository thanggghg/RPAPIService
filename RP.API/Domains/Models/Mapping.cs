using AutoMapper;
using RP.Comments.Application.Queries.Comments;
using RP.Comments.Database.Entities.Comments;
using RP.Commissions.Application.Queries;
using RP.Commissions.Models.Entities;

namespace RP.API.Domains.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateCommentsModelQuery, Comment>();
            CreateMap<EditCommentsModelQuery, Comment>();

            CreateMap<CommentMedia, RP.Comments.Application.Queries.Comments.Media>()
            .ForMember(dest => dest.OriginFileName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FullPath, opt => opt.MapFrom(src => $"{src.Path}/{src.MediaUuid}.{src.Extension}"))
            .ForMember(dest => dest.ImageUUID, opt => opt.MapFrom(src => src.MediaUuid));

            CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Medias, opt => opt.MapFrom(src => src.CommentMedias));

            CreateMap<CreateCommissionProductModelQuery, CommissionProduct>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionProductModelQuery, CommissionProduct>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionRuleModelQuery, CommissionRule>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionGroupMultiLevelModelQuery, CommissionGroupMultiLevel>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionRevenueModelQuery, CommissionRevenue>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionRevenueModelQuery, CommissionRevenue>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionRevenueQuantityModelQuery, CommissionRevenueQuantity>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionRevenueQuantityModelQuery, CommissionRevenueQuantity>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionPriorityModelQuery, CommissionPriority>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionPriorityModelQuery, CommissionPriority>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionExpandOptionModelQuery, CommissionExpandOption>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionExpandOptionModelQuery, CommissionExpandOption>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<CreateCommissionCategoryModelQuery, CommissionCategory>()
           .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EditCommissionCategoryModelQuery, CommissionCategory>()
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
