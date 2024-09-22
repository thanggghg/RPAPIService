using RP.Affiliate.PublisherManagement.Commands;
using RP.Affiliate.PublisherManagement.Commons;
using RP.Affiliate.PublisherManagement.Database;
using RP.Affiliate.PublisherManagement.Queries;
using RP.Affiliate.PublisherManagement.Repositories;
using RP.Affiliate.PublisherManagement.Services.Email;
using RP.Affiliate.PublisherManagement.Services.OrderPackage;
using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Repositories;
using RP.Library.Db;

internal static class RPAPIExtension
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
