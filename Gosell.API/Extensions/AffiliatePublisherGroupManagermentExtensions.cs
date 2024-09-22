using GoSell.Affiliate.PublisherGroupManagement.Application.Commands;
using GoSell.Affiliate.PublisherGroupManagement.Application.Queries;
using GoSell.Affiliate.PublisherGroupManagement.Domain.Interfaces;
using GoSell.Affiliate.PublisherGroupManagement.Infrastructure;
using GoSell.Affiliate.PublisherGroupManagement.Infrastructure.Repositories;
using GoSell.Affiliate.PublisherGroupManagement.Services.Implements;
using GoSell.Affiliate.PublisherGroupManagement.Services.Interfaces;
using GoSell.Library.Db;
using GoSell.Library.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GoSell.API.Extensions
{
    public static class AffiliatePublisherGroupManagermentExtensions
    {
        public static void AddAffiliatePublisherGroupManagermentServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;
            services.AddScoped<IGenericDbContext<PublisherGroupManagementContext>, GenericDbContext<PublisherGroupManagementContext>>();
            services.AddDbContext<PublisherGroupManagementContext>(options => options.UseNpgsql($"{configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")};Include Error Detail=true;",
                x => x.MigrationsHistoryTable("__MigrationsHistory", "affiliate-tracking-services"))
               );

            services.AddMigration<PublisherGroupManagementContext>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(GetAffiliateGroupPublisherQuery));
                cfg.RegisterServicesFromAssemblyContaining(typeof(CreateGroupPublisherCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(DeleteGroupPublisherCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(InsertPublisherToGroupCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(PublishGroupPublisherCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(RemovePublisherFromGroupCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(UpdateGroupPublisherCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(FilterListPublishersQuery));
                cfg.RegisterServicesFromAssemblyContaining(typeof(GetListPublishersQuery));
                cfg.RegisterServicesFromAssemblyContaining(typeof(FilterListPublisherGroupQuery));
                cfg.RegisterServicesFromAssemblyContaining(typeof(FilterListPublishedGroupHistoryQuery));
            });

            //DI
            services.AddScoped(typeof(IPublisherGroupManagementRepository<>), implementationType: typeof(PublisherGroupManagementRepository<>));
            builder.Services.AddScoped<IGroupPublisherService, GroupPublisherService>();

            builder.Services.AddHealthChecks()
              .AddDbContextCheck<PublisherGroupManagementContext>("PublisherGroupManagementContext")
              .AddCheck("GroupPublisherService", () => HealthCheckResult.Healthy());
        }
    }
}
