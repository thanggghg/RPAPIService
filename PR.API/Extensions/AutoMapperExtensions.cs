using AutoMapper;
using GoSell.Affiliate.Authentication.Application.Mappers;
using GoSell.Affiliate.Commissions.Mappers;
using GoSell.Affiliate.PublisherGroupManagement.Helper.Mapper;
using GoSell.Affiliate.PublisherManagement.Commons;
using GoSell.Affiliate.Tracking.Mapper;
using GoSell.API.Domains.Models;
using GoSell.Forum.Helpers.Mappers;
using GoSell.SocialAuthentication.Application.Mappers;

internal static class AutoMapperExtensions
{
    public static void AddAutoMapperExtension(this IHostApplicationBuilder builder)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new Mapping());
            mc.AddProfile(new AffiliateAuthenticationProfile());
            mc.AddProfile(new AffiliateProfile());
            mc.AddProfile(new CommissionCalculationProfile());
            mc.AddProfile(new PublisherManagementProfile());
            mc.AddProfile(new AffiliateGroupPublisherProfile());
            mc.AddProfile(new SocialAuthProfile());
            mc.AddProfile(new ForumProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}


