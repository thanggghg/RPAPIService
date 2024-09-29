using FluentValidation;
using RP.Library.Db;
using RP.Library.Extensions;
using RP.Library.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Polly;
using RP.GobalCore.Database;
using RP.GobalCore.Application.Handler.AuthenticateHandler;
using Microsoft.EntityFrameworkCore;
using RP.GobalCore.Services.Interfaces;
using RP.GobalCore.Services;
using RP.API.Service;
using RP.GobalCore.Repositories;
using Microsoft.Extensions.Logging;

public static class RPAPIExtension
{
    public static void AddGobalCoreExtension(this IHostApplicationBuilder builder)
    {

        var services = builder.Services;
        var configuration = builder.Configuration;
        //services.AddScoped<IGenericDbContext<ErpoutsourceContext>, GenericDbContext<ErpoutsourceContext>>();

        //services.AddDbContext<ERPOutsourceContext>(options =>
        //options.UseSqlServer(builder.Configuration.GetConnectionStringEnvironment("SQLDB")));

        services.AddDbContext<ErpoutsourceContext>(options =>
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            options.UseLoggerFactory(loggerFactory)
                   .EnableSensitiveDataLogging() // Cẩn thận với thông tin nhạy cảm trong production!
                   .UseSqlServer(builder.Configuration.GetConnectionStringEnvironment("SQLDB"));
        });

        Console.WriteLine($"Connectionstring of UseSqlServer : ${builder.Configuration.GetConnectionStringEnvironment("SQLDB")}");
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(AuthenticateHandler));
        });
        services.AddHttpClient(ApiNameConstants.WU_PLANING.ToString()).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        }).SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(5)));

        //services.AddScoped(typeof(IERPOutsourceRepository<>), implementationType: typeof(IERPOutsourceRepository<>));
        services.AddScoped(typeof(IERPOutsourceRepository<>), typeof(ERPOutsourceRepository<>));
        builder.Services.AddHealthChecks()
                    .AddDbContextCheck<ERPOutsourceContext>("ERPOutsourceContext")
                    .AddCheck("ERPOutsourceService", () => HealthCheckResult.Healthy());
    }
}
