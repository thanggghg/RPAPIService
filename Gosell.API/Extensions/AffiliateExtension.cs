using GoSell.Affiliate.PublisherManagement.Commands;
using GoSell.Affiliate.PublisherManagement.Commons;
using GoSell.Affiliate.PublisherManagement.Database;
using GoSell.Affiliate.PublisherManagement.Queries;
using GoSell.Affiliate.PublisherManagement.Repositories;
using GoSell.Affiliate.PublisherManagement.Services.Email;
using GoSell.Affiliate.PublisherManagement.Services.OrderPackage;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Library.Db;

internal static class AffiliateExtension
{
    public static void AddAffiliateTrackingServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
        services.AddDbContext<AffiliateContext>(options => options.UseNpgsql(configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")));
        services.AddScoped<IGenericDbContext<AffiliateContext>, GenericDbContext<AffiliateContext>>();
        services.AddScoped<IOrderPackageService, OrderPackageService>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(CreateClickTrackingCommand));
        });
        //Mapper
        services.AddScoped(typeof(IAffiliateRepository<>), implementationType: typeof(AffiliateRepository<>));
    }

    public static void AddAffiliatePublisherManagementServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        // database
        services.AddDbContext<PublisherManagementContext>(options => options.UseNpgsql(configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")));
        services.AddScoped<IGenericDbContext<PublisherManagementContext>, GenericDbContext<PublisherManagementContext>>();

        // service
        services.AddScoped(typeof(IPublisherManagementRepository<>), implementationType: typeof(PublisherManagementRepository<>));
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<IOrderPackageService, OrderPackageService>();
        services.AddSingleton(builder.Configuration
                            .GetSection("EmailConfigurations")
                            .Get<EmailConfigurations>());
        services.AddSingleton(builder.Configuration
                            .GetSection("JavaConfig")
                            .Get<JavaConfig>());

        // handler
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(GetPublishersByStoreQuery));
            cfg.RegisterServicesFromAssemblyContaining(typeof(UpdatePublisherStoreStatusCommand));
            cfg.RegisterServicesFromAssemblyContaining(typeof(GetStoreByIdQuery));
            cfg.RegisterServicesFromAssemblyContaining(typeof(GetPublisherStatusByStoreQuery));

        });

    }
}
