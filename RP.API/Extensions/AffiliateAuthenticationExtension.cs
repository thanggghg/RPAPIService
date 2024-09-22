using GoSell.Affiliate.Authentication.Application.Behaviors.Validations;
using GoSell.Affiliate.Authentication.Application.Commands;
using GoSell.Affiliate.Authentication.Application.Handler;
using GoSell.Affiliate.Authentication.Domain.Enums;
using GoSell.Affiliate.Authentication.Domain.Repositories;
using GoSell.Affiliate.Authentication.Infrastructure.Persistence;
using GoSell.Affiliate.Authentication.Infrastructure.Persistence.Repositories;
using GoSell.Affiliate.Authentication.Models;
using GoSell.Affiliate.Authentication.Services;
using GoSell.Affiliate.Authentication.Services.Interfaces;
using GoSell.Library.Db;
using GoSell.Library.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProxyClient.Models.Responses.Tel4vn;
using static GoSell.Affiliate.Authentication.SocialDynamicDelegateService;

namespace GoSell.API.Extensions
{
    public static class AffiliateAuthenticationExtension
    {
        public static void AddAffiliateAuthenticationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddDbContext<AffiliateAuthContext>(options => options.UseNpgsql($"{configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")};Include Error Detail=true;",
                x => x.MigrationsHistoryTable("__MigrationsHistory", "affiliate-tracking-services")));

            services.AddMigration<AffiliateAuthContext>();

            services.AddSingleton(builder.Configuration
                    .GetSection("Tel4vnConfigurations")
                    .Get<Tel4vnConfigurations>());

            services.AddSingleton(builder.Configuration
                    .GetSection("OTPConfigurations")
                    .Get<OTPConfigurations>());

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(SigninCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(SendSMSOTPAffiliateCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(SignupCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(VerifyOtpCommand));
                cfg.RegisterServicesFromAssemblyContaining(typeof(SocialSigninCommand));
            });

            //Validation
            builder.Services.AddScoped<IValidator<SigninCommand>, SigninValidation>();
            builder.Services.AddScoped<IValidator<SigninCommand>, LangKeyValidation>();
            builder.Services.AddScoped<IValidator<SigninCommand>, PhoneNumberValidation>();

            builder.Services.AddScoped<IValidator<SignupCommand>, SignupValidation>();
            builder.Services.AddScoped<IValidator<SignupCommand>, LangKeyValidation>();
            builder.Services.AddScoped<IValidator<SignupCommand>, PhoneNumberValidation>();

            builder.Services.AddScoped<IValidator<ResetPasswordCommand>, ResetPasswordCommandValidation>();
            builder.Services.AddScoped<IValidator<ResetPasswordCommand>, PhoneNumberValidation>();

            builder.Services.AddScoped<IValidator<SendSMSOTPAffiliateCommand>, PhoneNumberValidation>();

            builder.Services.AddScoped<IValidator<VerifyOtpCommand>, PhoneNumberValidation>();
            builder.Services.AddScoped<IValidator<VerifyOtpCommand>, VerifyOtpCommandValidation>();

            services.AddScoped(typeof(IAffiliateAuthRepository<>), implementationType: typeof(AffiliateAuthRepository<>));

            builder.Services.AddScoped<IValidator<UserProfileCommand>, UserProfileValidation>();
            builder.Services.AddScoped<IValidator<ChangePasswordCommand>, ChangePasswordValidation>();
            builder.Services.AddScoped<IValidator<ChangePasswordCommand>, PasswordValidation>();

            //DI
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<ISocialAuthenService, SocialAuthenService>();

            services.AddScoped<IDynamicDomainSocialService, GoogleDynamicDomainService>();
            services.AddScoped<GoogleDynamicDomainService>();
            services.AddScoped<IDynamicDomainSocialService, AppleDynamicDomainService>();
            services.AddScoped<AppleDynamicDomainService>();
            services.AddScoped<IDynamicDomainSocialService, FacebookDynamicDomainService>();
            services.AddScoped<FacebookDynamicDomainService>();
            services.AddScoped<SocialDynamicDelegateServiceResolver<IDynamicDomainSocialService>>(serviceProvider => type =>
            {
                if (type == SocialDynamicProviderEnum.Google) return serviceProvider.GetService<GoogleDynamicDomainService>();
                if (type == SocialDynamicProviderEnum.Apple) return serviceProvider.GetService<AppleDynamicDomainService>();
                if (type == SocialDynamicProviderEnum.Facebook) return serviceProvider.GetService<FacebookDynamicDomainService>();

                throw new KeyNotFoundException();
            });

            builder.Services.AddHealthChecks()
            .AddDbContextCheck<AffiliateAuthContext>("AffiliateAuthContext")
            .AddCheck("AffiliateAuthService", () => HealthCheckResult.Healthy());
        }
    }
}
