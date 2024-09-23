using FluentValidation;
using RP.Affiliate.Tracking.Config;
using RP.Affiliate.Tracking.Database;
using RP.Library.Db;
using RP.Library.Extensions;
using RP.Library.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Polly;

public static class RPAPIExtension
{
    public static void AddGobalCoreExtension(this IHostApplicationBuilder builder)
    {

        var services = builder.Services;
        var configuration = builder.Configuration;
        services.AddScoped<IGenericDbContext<ERPOutsourceContext>, GenericDbContext<ERPOutsourceContext>>();
        services.AddDbContext<ERPOutsourceContext>(options => options.UseNpgsql($"{builder.Configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")};Include Error Detail=true;",
           x => x.MigrationsHistoryTable("__MigrationsHistory", "affiliate-tracking-services"))
            );
        services.AddMigration<ERPOutsourceContext>();
        //services.AddMediatR(cfg =>
        //{
        //    cfg.RegisterServicesFromAssemblyContaining(typeof(CreateClickTrackingCommand));
        //});
        services.AddHttpClient(ApiNameConstants.AFFiLIAATE_TRACKING.ToString()).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(5)));
        var affiliateConfig = configuration
            .GetSectionWithEnvironment("AffConfig")
            .Get<AffiliateConfig>();
        services.AddSingleton(affiliateConfig);

        builder.Services.AddHealthChecks()
                .AddDbContextCheck<ERPOutsourceContext>("AffiliateContext")
                .AddCheck("AffiliateService", () => HealthCheckResult.Healthy());
        //services.AddScoped<ExportAffiliateUrlReportService>();
        //services.AddExportRequestHandler<ExportAffUrlReportQuery>();
        //services.AddExportCommonService<ExportAffUrlReportQuery>();

        //var serviceMappings = new Dictionary<string, Type>
        //{
        //    { ExportCommonServiceType.affiliateUrlReport.ToString(), typeof(ExportAffiliateUrlReportService) },
        //};

        //services.AddDynamicExportDataMapperResolver<ExportAffUrlReportQuery>(serviceMappings);
    }
}
