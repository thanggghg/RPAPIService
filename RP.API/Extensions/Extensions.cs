using System.Reflection;
using GoSell.API.Exceptions;
using GoSell.Comments.Repositories.Implements;
using GoSell.Comments.Repositories.Interfaces;
using GoSell.Commissions.Extensions;
using GoSell.Common.Constants;
using GoSell.Common.Services.Implements;
using GoSell.Common.Services.Implements.Facebook;
using GoSell.Common.Services.Interfaces;
using GoSell.CommonHistory.Extensions;
using GoSell.CommonTicket.Extensions;
using GoSell.EWarranty.Extensions;
using GoSell.FBBulkPosting.Extension;
using GoSell.Forum.Extensions;
using GoSell.Library.Db;
using GoSell.Library.Extensions;
using GoSell.Library.Extensions.JWT;
using GoSell.Library.Extensions.Permission;
using GoSell.Library.Extensions.Social;
using GoSell.Library.Helpers;
using GoSell.Library.Helpers.Api;
using GoSell.Library.Helpers.Service;
using GoSell.Library.Utils;
using GoSell.Payments.Extension;
using GoSell.SocialAuthentication.Application.Queries;
using GoSell.SocialAuthentication.Infrastructure.Persistence.Repositories;
using GoSell.SocialAuthentication.Infrastructure.Persistence.Repositories.Interfaces;
using GoSell.SupportTicket.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using ProxyClient.Helpers;
using ProxyClient.Services;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using static GoSell.Common.Services.DelegateService;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddEndpointsApiExplorer();

        var configuration = builder.Configuration.Build();
        Console.WriteLine($"Connectionstring of GoSellDB : ${builder.Configuration.GetConnectionStringEnvironment("GoSellDB")}");
        Console.WriteLine($"Connectionstring of AffiliateTrackingConnection: ${builder.Configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")}");

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddProblemDetails();
        services.AddCors(options =>
        {
            var allowedOrigins = configuration
                .GetSectionValueWithEnvironment("AllowedOrigins")
                .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            options.AddPolicy("AllowSpecificOrigin", cor =>
            {
                cor.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetPreflightMaxAge(TimeSpan.FromDays(30))
                .AllowCredentials()
                .SetIsOriginAllowed((string hostname) => { return true; })
                .WithOrigins(allowedOrigins);
            });
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer {token}'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                      Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    }, new List<string>()
                }
            });

            c.CustomSchemaIds(type => type.ToString());
        });
        // Add the authentication & Authorization
        var jwtOptions = configuration
            .GetSectionWithEnvironment("JwtOptions")
            .Get<JwtOptions>();
        var authorizationConstants = configuration
            .GetSectionWithEnvironment("AuthorizationConstants")
            .Get<AuthorizationConstants>();

        // Add the Apple social options
        var appleSocialSettings = builder.Configuration.GetSection("Socials:Apple:Settings").Get<AppleSocialSettings>();
        services.AddSingleton(appleSocialSettings);

        // Add the Google social options
        var googleSocialSettings = builder.Configuration.GetSection("Socials:Google:Settings").Get<GoogleSocialSettings>();
        services.AddSingleton(googleSocialSettings);

        // Add the Facebook social options
        var facebookSocialSettings = builder.Configuration.GetSection("Socials:Facebook:Settings").Get<FacebookConfiguration>();
        services.AddSingleton(facebookSocialSettings);

        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("GoSellDB")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("GatewayServicesConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("PaymentServicesConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("CashbookServicesConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("WareHouseDB")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("CommonTicketServicesConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("EWarrantyServicesConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("AffiliateTrackingConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("CommentServiceConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("CommonHistoryConnection")};Include Error Detail=true;"));
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("ForumServicesConnection")};Include Error Detail=true;"));
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddSingleton(jwtOptions);
        services.AddSingleton(authorizationConstants);
        services.AddCachesMemoryOrRedis();
        services.AddJiraConfiguration();
        services.AddMailClientConfiguration();
        services.AddHttpContextAccessor();
        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
            cfg.RegisterServicesFromAssemblyContaining(typeof(PaymentExtension)); // note inject mediatR\
            cfg.RegisterServicesFromAssemblyContaining(typeof(SignInQueries)); cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.RegisterServicesFromAssemblyContaining(typeof(WarrantyExtension)); // note inject mediatR
            cfg.RegisterServicesFromAssemblyContaining(typeof(AnalysisExtension)); // note inject mediatR
            cfg.RegisterServicesFromAssemblyContaining(typeof(CommissionExtension)); // note inject mediatR
            cfg.RegisterServicesFromAssemblyContaining(typeof(CommentsExtensions));
            cfg.RegisterServicesFromAssemblyContaining(typeof(ForumExtension));
            cfg.RegisterServicesFromAssemblyContaining(typeof(AffiliateAuthenticationExtension)); // note inject mediatR
            cfg.RegisterServicesFromAssemblyContaining(typeof(SupportTicketExtension));
            cfg.RegisterServicesFromAssemblyContaining(typeof(CommonTicketExtension));
            cfg.RegisterServicesFromAssemblyContaining(typeof(CommonHistoryExtension));
            cfg.RegisterServicesFromAssemblyContaining(typeof(FBBulkPostingExtension));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });
        //JWT Authorization role ADMIN
        services.AddAuthentication();
        services.AddAuthorization(o =>
        {
            o.AddPolicy(AuthoritiesConstants.ADMIN, p => p.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.ADMIN)));
            o.AddPolicy(AuthoritiesConstants.STORE, p => p.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.STORE)));
            o.AddPolicy(AuthoritiesConstants.USER, p => p.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.USER)));
            o.AddPolicy(AuthoritiesConstants.AFFILIATE, o => o.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.AFFILIATE)));
            o.AddPolicy(AuthoritiesConstants.AFFILIATE_PROFILE, o => o.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.AFFILIATE_PROFILE)));
            o.AddPolicy(AuthoritiesConstants.DEFAULT, o => o.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.DEFAULT)));
            o.AddPolicy(AuthoritiesConstants.GUEST, o => o.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.GUEST)));
            o.AddPolicy(AuthoritiesConstants.GUEST_CHECKOUT, o => o.AddRequirements(new JWTTokenRequirement(AuthoritiesConstants.GUEST_CHECKOUT)));

        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        services.AddSingleton<IAuthorizationHandler, JWTTokenRequirementHandle>();
        services.AddSingleton<IAuthorizationHandler, StaffPermissionRequirementHandle>();
        services.AddSingleton<IOauthClientDetailsService, OauthClientDetailsService>();
        services.AddTransient<IHttpClientHelper, HttpClientHelper>();
        services.AddScoped<ICommentsRepository, CommentsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDomainRepository, UserDomainRepository>();
        services.AddScoped<IUserAuthorityRepository, UserAuthorityRepository>();
        services.AddScoped<ISocialUserConnectionRepository, SocialUserConnectionRepository>();
        services.AddScoped<IOauthClientDetailRepository, OauthClientDetailRepository>();
        services.AddScoped<IBaseApi, BaseApi>();
        services.AddScoped<IBaseService, BaseService>();

        //Service common
        services.AddScoped<GoogleServices>();
        services.AddScoped<AppleServices>();
        services.AddScoped<FacebookService>();
        services.AddScoped<SocialServiceResolver<IProviderSocialServices>>(serviceProvider => key =>
        {
            if (key == SocialConstant.Google) return serviceProvider.GetService<GoogleServices>();
            if (key == SocialConstant.Apple) return serviceProvider.GetService<AppleServices>();
            if (key == SocialConstant.Facebook) return serviceProvider.GetService<FacebookService>();
            throw new KeyNotFoundException();
        });

        //Proxy client
        services.RegisterProxyClientService();

        var root = builder.Configuration.Build();
        Log.Logger = new LoggerConfiguration()
            .Enrich.WithProperty("app_name", Assembly.GetEntryAssembly().GetName().Name)
            .Enrich.WithProperty("app_port", Environment.GetEnvironmentVariable("APP_PORT") ?? string.Empty)
            .WriteTo.Elasticsearch(ConfigureElasticSink(root))
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        builder.AddElasticClient();
        services.AddSingleton(Log.Logger);

    }

    public static void RegisterProxyClientService(this IServiceCollection services)
    {
        services.AddScoped<IBeehiveService, BeehiveService>();
        services.AddScoped<IAffiliateService, AffiliateService>();
        services.AddScoped<IHttpClientFactoryHelper, HttpClientFactoryHelper>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<IAffiliateTrackingService, AffiliateTrackingService>();
        services.AddScoped<IGatewayService, GatewayService>();
    }

    public static void AddAppConfigure(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", SwaggerConstants.SwaggerTitle));
        app.UseCors("AllowSpecificOrigin");
        app.UseAuthorization();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //app.UseMiddleware<JwtMiddlewareExtension>();
    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration)
    {
        var nodeUri = configuration.GetSectionWithEnvironment("Serilog:WriteTo:0:Args").GetValue<string>("nodeUris");
        return new ElasticsearchSinkOptions(new Uri(nodeUri))
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
            TypeName = null
        };
    }
}
