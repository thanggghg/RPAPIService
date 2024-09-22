using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateCampaign;
using GoSell.Affiliate.Tracking.Commands.AffiliateCategory;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Commons.Enums;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Library.Helpers.Pagination;

namespace GoSell.Affiliate.Tracking.Mapper
{
    public class AffiliateProfile : Profile
    {
        public AffiliateProfile()
        {
            CreateMap<AffiliateStore, AffiliateStoreViewModel>()
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.AffiliateStoreCurrencyId));
            CreateMap<AffiliateStore, AffiliateStoreByDomainViewModel>();
            CreateMap<AffiliateTheme, AffiliateThemeViewModel>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateThemeViewModel = new AffiliateThemeViewModel
                    {
                        Id = src.Id,
                        IsDeleted = src.IsDeleted,
                        PrimaryColor = src.AffiliateColorDefault.PrimaryColor,
                        SecondaryColor = src.AffiliateColorDefault.SecondaryColor,
                        IsPublished = src.IsPublished,
                        CoverImage = src.CoverImage,
                        Logo = src.Logo,
                        ColorId = src.ColorId,
                    };

                    return affiliateThemeViewModel;
                }); ;
            CreateMap<CreateAffiliateStoreCommand, AffiliateStore>();
            CreateMap<UpdateAffiliateStoreCommand, AffiliateStore>();
            CreateMap<CreateClickTrackingCommand, AffiliateClickTracking>();
            CreateMap<CreateThemeCommand, AffiliateTheme>();
            CreateMap<UpdateThemeCommand, AffiliateTheme>();

            //Submission
            CreateMap<AffiliateSubmission, AffiliateSubmissionViewModel>();
            CreateMap<CreateAffiliateSubmissionCommand, AffiliateSubmission>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateSubmission = new AffiliateSubmission
                    {
                        ConversionId = src.ConversionId,
                        TrackingIds = string.Join(",", src.TrackingIds),
                        ClickId = src.ClickId,
                        SubmissionType = (int)src.SubmissionType,
                        Status = (int)SubmissionStatusEnum.PENDING,
                        DiscountAmount = src.DiscountAmount.Value,
                        GroupId = src.GroupId,
                        FeeAmount = src.FeeAmount.Value,
                        OrderId = Convert.ToString(src.OrderId),
                        TotalAmount = src.TotalAmount.Value,
                        TaxAmount = src.TaxAmount.Value,
                        SubTotalAmount = src.SubTotalAmount.Value,
                        ShippingFee = src.ShippingFee.Value,
                        PaymentMethod = src.PaymentMethod,
                        CustomerName = src.CustomerName,
                        CustomerPhone = src.CustomerPhone,
                        CustomerAddress = src.CustomerAddress,
                        OrderCreatedDate = src.CreatedSubmissionTime.Value,
                    };

                    return affiliateSubmission;
                });
            CreateMap<CreateAffiliateSubmissionCommand, List<AffiliateOrderDetail>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateSubmission = src.OrderItems.Select(x => new AffiliateOrderDetail
                    {
                        ProductId = x.ProductId,
                        Sku = x.Sku,
                        Quantity = x.Quantity.Value,
                        CategoryId = x.CategoryId,
                        TotalPrice = x.TotalPrice.Value,
                        ItemName = x.ItemName,
                        SalePrice = x.SalePrice.Value,
                        Price = x.Price.Value,
                    }).ToList();

                    return affiliateSubmission;
                });


            CreateMap<CreateAffiliateSubmissionByScriptCommand, AffiliateSubmission>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateSubmission = new AffiliateSubmission
                    {
                        ConversionId = src.ConversionId,
                        TrackingIds = src.TrackingIds?.Count > 0 ? string.Join(",", src.TrackingIds) : "",
                        ClickId = src.ClickId,
                        SubmissionType = (int)src.SubmissionType,
                        Status = (int)SubmissionStatusEnum.PENDING,
                        DiscountAmount = src.DiscountAmount ?? 0m,
                        GroupId = src.GroupId,
                        FeeAmount = src.FeeAmount ?? 0m,
                        OrderId = Convert.ToString(src.OrderId),
                        TotalAmount = src.TotalAmount ?? 0m,
                        TaxAmount = src.TaxAmount ?? 0m,
                        SubTotalAmount = src.SubTotalAmount ?? 0m,
                        ShippingFee = src.ShippingFee ?? 0m,
                        PaymentMethod = src.PaymentMethod,
                        OrderCreatedDate = src.CreatedSubmissionTime.Value,
                    };

                    return affiliateSubmission;
                });
            CreateMap<CreateAffiliateSubmissionByScriptCommand, List<AffiliateOrderDetail>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateSubmission = src.OrderItems.Select(x => new AffiliateOrderDetail
                    {
                        ProductId = x.ProductId,
                        Sku = x.Sku,
                        Quantity = x.Quantity.Value,
                        CategoryId = x.CategoryId,
                        TotalPrice = x.TotalPrice.Value,
                        ItemName = x.ItemName,
                        Price = x.Price.Value,
                        SalePrice = x.SalePrice.Value,
                    }).ToList();

                    return affiliateSubmission;
                });
            CreateMap<AffiliateSubmission, OrderDetailsViewModel>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateSubmission = new OrderDetailsViewModel()
                    {
                        AffiliateOrderDetails = src.AffiliateOrderDetails?.Where(x => !x.IsDeleted).Select(x => new AffiliateOrderViewModel
                        {
                            CategoryId = x.CategoryId,
                            ItemName = x.ItemName,
                            Price = x.Price,
                            SalePrice = x.SalePrice,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            Sku = x.Sku,
                            SubmissionId = x.SubmissionId,
                            TotalPrice = x.TotalPrice
                        }).ToList(),
                        ClickId = src.ClickId,
                        DiscountAmount = src.DiscountAmount,
                        ExternalStoreId = src.ExternalStoreId,
                        FeeAmount = src.FeeAmount,
                        GroupId = src.GroupId,
                        OrderCreatedDate = src.OrderCreatedDate,
                        OrderId = src.OrderId,
                        PaymentMethod = src.PaymentMethod,
                        ShippingFee = src.ShippingFee,
                        Status = src.Status,
                        SubmissionType = src.SubmissionType,
                        SubTotalAmount = src.SubTotalAmount,
                        PartnerId = src.PartnerId,
                        TaxAmount = src.TaxAmount,
                        TotalAmount = src.TotalAmount,
                        CustomerAddress = src.CustomerAddress,
                        CustomerPhone = src.CustomerPhone,
                        CustomerName = src.CustomerName,
                        TrackingIds = src.TrackingIds?.Split(',').ToList(),
                        LastModifiedBy = src.LastModifiedBy,
                        LastModifiedDate = src.LastModifiedDate.Value,
                    };

                    return affiliateSubmission;
                });

            CreateMap<CreateAffiliateLinkCommand, AffiliateLink>()
            .ForMember(dest => dest.OriginLink, opt => opt.MapFrom(src => src.OriginLinks.Count > 0 ? src.OriginLinks[0] : null));

            CreateMap<CreateAffiliateLinkCommand, List<AffiliateLink>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var affiliateLinks = new List<AffiliateLink>();

                    foreach (var originLink in src.OriginLinks)
                    {
                        var affiliateLink = new AffiliateLink
                        {
                            CampaignId = src.CampaignId,
                            OriginLink = originLink,
                            SubId1 = src.SubId1,
                            SubId2 = src.SubId2,
                            SubId3 = src.SubId3,
                            SubId4 = src.SubId4,
                            SubId5 = src.SubId5,
                        };
                        affiliateLinks.Add(affiliateLink);
                    }

                    return affiliateLinks;
                });

            CreateMap<AffiliateSubmission, OrderDetailsOfPublisherViewModel>()
                .ConvertUsing((src, dest, context) =>
                {
                    var output = new OrderDetailsOfPublisherViewModel()
                    {
                        CreatedDate = src.OrderCreatedDate,
                        DiscountFee = src.DiscountAmount,
                        OrderStatus = (SubmissionStatusEnum)src.Status,
                        OrderId = src.OrderId,
                        Products = src.AffiliateOrderDetails?.Select(x => new ProductDetailsViewModel()
                        {
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            Total = x.TotalPrice,
                            CategoryId = x.CategoryId
                        }).ToList(),
                        TaxFee = src.TaxAmount,
                        Total = src.TotalAmount,
                        ShippingFee = src.ShippingFee,
                    };
                    return output;
                });

            //Affiliate Product
            CreateMap<CreateAffiliateProductCommand, AffiliateProduct>();

            CreateMap<UpdateAffiliateProductCommand, AffiliateProduct>();
            CreateMap<DeleteAffiliateProductCommand, AffiliateProduct>();
            CreateMap<ChangeStatusAffiliateProductCommand, AffiliateProduct>();
            CreateMap<AffiliateProduct, AffiliateProductViewModel>();


            CreateMap<PagingItems<AffiliateProduct>, PagingItems<AffiliateProductViewModel>>();
            CreateMap<AffiliateColorDefault, AffiliateKeyValueViewModel>()
                .ForMember(v => v.Value, opt => opt.MapFrom(s => s.PrimaryColor));

            CreateMap<AffiliateBusiness, AffiliateKeyValueViewModel>()
                .ForMember(v => v.Value, opt => opt.MapFrom(s => s.LanguageKey));

            CreateMap<AffiliateStoreCurrency, AffiliateStoreCurrencyViewModel>();

            //Affiliate Category 
            CreateMap<CreateAffiliateCategoryCommand, AffiliateCategory>();
            CreateMap<UpdateAffiliateCategoryCommand, AffiliateCategory>();
            CreateMap<DeleteAffiliateCategoryCommand, AffiliateCategory>();
            CreateMap<ChangeStatusAffiliateCategoryCommand, AffiliateCategory>();
            CreateMap<AffiliateCategory, AffiliateCategoryViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.RefCategoryId, opt => opt.MapFrom(src => src.RefCategoryId))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
              .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
              .ForMember(dest => dest.AffiliateStoreId, opt => opt.MapFrom(src => src.AffiliateStoreId));
            CreateMap<AffiliateCategory, AffiliateCategoryPublicViewModel>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                          .ForMember(dest => dest.RefCategoryId, opt => opt.MapFrom(src => src.RefCategoryId))
                          .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                          .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                          .ForMember(dest => dest.AffiliateStoreId, opt => opt.MapFrom(src => src.AffiliateStoreId));

            CreateMap<PagingItems<AffiliateCategory>, PagingItems<AffiliateCategoryViewModel>>();
            CreateMap<PagingItems<AffiliateCategory>, PagingItems<AffiliateCategoryPublicViewModel>>();


            //Affiliate Campaign
            CreateMap<CreateOrUpdateAffiliateCampaignCommand, AffiliateCampaign>();
            CreateMap<DeleteAffiliateCampaignCommand, AffiliateCampaign>();
            CreateMap<AffiliateCampaign, AffiliateCampaignViewModel>();
            CreateMap<PagingItems<AffiliateCampaign>, PagingItems<AffiliateCampaignViewModel>>();

            //Affiliate Mapping
            CreateMap<CreateAffiliateMappingViewModel, AffiliateMapping>();
            CreateMap<AffiliateMapping, AffiliateMappingViewModel>();
        }
    }
}
