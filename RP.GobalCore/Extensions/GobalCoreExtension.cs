using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Polly;
using RP.API.Service;
using RP.GobalCore.Application.Handler.AuthenticateHandler;
using RP.GobalCore.Database;
using RP.GobalCore.Repositories;
using RP.GobalCore.Services;
using RP.GobalCore.Services.Interfaces;
using RP.Library.Db;
using RP.Library.Utils;

public static class RPAPIExtension
{
    public static void AddGobalCoreExtension(this IHostApplicationBuilder builder)
    {

        var services = builder.Services;
        var configuration = builder.Configuration;
        services.AddScoped<IGenericDbContext<ERPOutsourceContext>, GenericDbContext<ERPOutsourceContext>>();

        services.AddDbContext<ERPOutsourceContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionStringEnvironment("SQLDB")));
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
