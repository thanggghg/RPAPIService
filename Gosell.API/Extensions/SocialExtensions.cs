using GoSell.Common;
using GoSell.Common.Enums;
using GoSell.Library.Db;
using GoSell.Library.Extensions.Social;
using GoSell.SocialAuthentication.Application.Behaviors.Validations;
using GoSell.SocialAuthentication.Contants;
using GoSell.SocialAuthentication.DB;
using GoSell.SocialAuthentication.Infrastructure.Services.Email;
using GoSell.SocialAuthentication.Models.Configurations;
using GoSell.SocialAuthentication.Services.Implementation;
using GoSell.SocialAuthentication.Services.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Polly;
using static GoSell.SocialAuthentication.Application.Queries.SignInQueries;
using static GoSell.SocialAuthentication.DelegateService;

internal static class SocialExtensions
{
    public static void AddSocialServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        //Add DB
        services.AddDbContext<SocialAuthContext>(options => options.UseNpgsql($"{configuration.GetConnectionStringEnvironment("GatewayServicesConnection")};Include Error Detail=true;"));

        //Add HttpClient
        services.AddHttpClient(HttpClientScopeEnum.SOCIAL.ToString()).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual
        }).SetHandlerLifetime(TimeSpan.FromMinutes(HttpClientConfigSettings.HANDLER_LIFETIME_MINUTES))
        .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(HttpClientConfigSettings.TRANSIENT_HTTP_ERROR_POLICY_RETRY, _ => TimeSpan.FromSeconds(HttpClientConfigSettings.TRANSIENT_HTTP_ERROR_POLICY_WAIT_SECONDS)));

        // Add the Apple social options
        var appleSocialSettings = builder.Configuration.GetSection("Socials:Apple:Settings").Get<AppleSocialSettings>();
        services.AddSingleton(appleSocialSettings);

        // Add the Google social options
        var googleSocialSettings = builder.Configuration.GetSection("Socials:Google:Settings").Get<GoogleSocialSettings>();
        services.AddSingleton(googleSocialSettings);

        //Add Services
        services.AddScoped<ISocialSignInServices, SocialSigninServices>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<GoogleServices>();
        services.AddScoped<AppleServices>();

        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddSingleton(builder.Configuration
                            .GetSection("EmailConfigurations")
                            .Get<EmailConfigurations>());
        services.AddSingleton(builder.Configuration
                            .GetSection("Socials")
                            .Get<SocialSettings>());
        services.AddSingleton(builder.Configuration
                            .GetSection("JavaConfig")
                            .Get<JavaConfig>());
        services.AddSingleton(builder.Configuration
                            .GetSection("DashboardDomain")
                            .Get<DashboardDomainConfiguration>());

        //Validation
        builder.Services.AddSingleton<IValidator<SignInQuery>, SignInQueryValidator>();

        //Filter provider
        services.AddScoped<SocialServiceResolver<IProviderSocialServices>>(serviceProvider => key =>
        {
            if (key == SocialConstants.Google) return serviceProvider.GetService<GoogleServices>();
            if (key == SocialConstants.Apple) return serviceProvider.GetService<AppleServices>();
            //if (key == SocialConstants.Facebook) return serviceProvider.GetService<FacebookServices>();
            throw new KeyNotFoundException();
        });

        builder.Services.AddHealthChecks()
        .AddDbContextCheck<SocialAuthContext>("SocialAuthContext")
        .AddCheck("SocialService", () => HealthCheckResult.Healthy());

    }
    public static void AddSocialConfigure(this WebApplication app)
    {
        //app.UseSwagger();
        //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", SwaggerConstants.SwaggerTitle));
        //app.UseHttpsRedirection();
        //app.UseCors("AllowSpecificOrigin");
        //app.UseAuthorization();
        //app.UseMiddleware<JwtMiddlewareExtension>();
    }
}


