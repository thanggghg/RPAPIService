using FluentValidation;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Commands.AffiliateProduct;
using GoSell.Affiliate.Tracking.Config;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Functions.Implementation;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Affiliate.Tracking.Queries;
using GoSell.Affiliate.Tracking.Repositories;
using GoSell.Affiliate.Tracking.Repositories.Interfaces;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.ExportAffiliateUrlReport;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Affiliate.Tracking.Validations.AffiliateProduct;
using GoSell.Affiliate.Tracking.Validations.AffiliateSubmission;
using GoSell.Common.Enums;
using GoSell.Common.Extension;
using GoSell.Library.Db;
using GoSell.Library.Extensions;
using GoSell.Library.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Polly;

public static class AffiliateExtension
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
        services.AddTransient<IAffiliateProductFunctions, AffiliateProductFunctions>();
        services.AddTransient<IAffiliateCategoryFunctions, AffiliateCategoryFunctions>();
        services.AddTransient<IImportAffiliateProductFunctions, ImportAffiliateProductFunctions>();
        services.AddTransient<IAffiliateCampaignFunctions, AffiliateCampaignFunctions>();
        services.AddScoped(typeof(IAffiliateRepository<>), implementationType: typeof(AffiliateRepository<>));
        services.AddScoped<IAffiliateProductRepository, AffiliateProductRepository>();
        services.AddScoped<IAffiliateCategoryRepository, AffiliateCategoryRepository>();
        services.AddScoped<IAffiliateCampaignRepository, AffiliateCampaignRepository>();
        services.AddScoped<IAffiliateCampaignProductRepository, AffiliateCampaignProductRepository>();

        services.AddSingleton<FluentValidation.IValidator<CreateAffiliateSubmissionCommand>, CreateAffiliateSubmissionCommandValidator>();
        services.AddScoped<IAffiliateTrackingServices, AffiliateTrackingServices>();
        services.AddScoped<IAffiliateStoreServices, AffiliateStoreServices>();
        services.AddScoped<IAffiliateSubmissionServices, AffiliateSubmissionServices>();
        services.AddScoped<IAffiliatePartnerServices, AffiliatePartnerServices>();
        services.AddScoped<IAffiliateMappingServices, AffiliateMappingServices>();


        services.AddSingleton<IValidator<CreateAffiliateSubmissionCommand>, CreateAffiliateSubmissionCommandValidator>();
        services.AddSingleton<IValidator<CreateAffiliateProductCommand>, CreateAffiliateProductCommandValidator>();
        services.AddSingleton<IValidator<UpdateAffiliateProductCommand>, UpdateAffiliateProductCommandValidator>();
        services.AddSingleton<IValidator<ImportAffiliateProductCommand>, ImportAffiliateProductCommandValidator>();
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
