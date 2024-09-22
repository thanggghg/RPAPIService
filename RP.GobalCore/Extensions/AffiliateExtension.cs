using FluentValidation;
using RP.Affiliate.Tracking.Commands;
using RP.Affiliate.Tracking.Commands.AffiliateProduct;
using RP.Affiliate.Tracking.Config;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Functions.Implementation;
using RP.Affiliate.Tracking.Functions.Interface;
using RP.Affiliate.Tracking.Queries;
using RP.Affiliate.Tracking.Repositories;
using RP.Affiliate.Tracking.Repositories.Interfaces;
using RP.Affiliate.Tracking.Services;
using RP.Affiliate.Tracking.Services.ExportAffiliateUrlReport;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.Validations.AffiliateProduct;
using RP.Affiliate.Tracking.Validations.AffiliateSubmission;
using RP.Common.Enums;
using RP.Common.Extension;
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
    public static void AddAffiliateTrackingExtension(this IHostApplicationBuilder builder)
    {

        var services = builder.Services;
        var configuration = builder.Configuration;
        services.AddScoped<IGenericDbContext<AffiliateContext>, GenericDbContext<AffiliateContext>>();
        services.AddDbContext<AffiliateContext>(options => options.UseNpgsql($"{builder.Configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")};Include Error Detail=true;",
           x => x.MigrationsHistoryTable("__MigrationsHistory", "affiliate-tracking-services"))
            );
        services.AddMigration<AffiliateContext>();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(CreateClickTrackingCommand));
        });
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
                .AddDbContextCheck<AffiliateContext>("AffiliateContext")
                .AddCheck("AffiliateService", () => HealthCheckResult.Healthy());
        services.AddScoped<ExportAffiliateUrlReportService>();
        services.AddExportRequestHandler<ExportAffUrlReportQuery>();
        services.AddExportCommonService<ExportAffUrlReportQuery>();

        var serviceMappings = new Dictionary<string, Type>
        {
            { ExportCommonServiceType.affiliateUrlReport.ToString(), typeof(ExportAffiliateUrlReportService) },
        };

        services.AddDynamicExportDataMapperResolver<ExportAffUrlReportQuery>(serviceMappings);
    }
}
