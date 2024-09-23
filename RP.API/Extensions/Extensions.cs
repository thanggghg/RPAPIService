using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using RP.API.Exceptions;
using RP.Library.Db;
using RP.Library.Extensions;
using RP.Library.Extensions.JWT;
using RP.Library.Utils;
using Serilog;
using Serilog.Sinks.Elasticsearch;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddEndpointsApiExplorer();

        var configuration = builder.Configuration.Build();
        Console.WriteLine($"Connectionstring of RPDB : ${builder.Configuration.GetConnectionStringEnvironment("SQLDB")}");
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
      
        services.AddSingleton<IDbConnection>(_ => new Npgsql.NpgsqlConnection($"{builder.Configuration.GetConnectionStringEnvironment("SQLDB")};Include Error Detail=true;"));

        services.AddSingleton(jwtOptions);
        //services.AddMailClientConfiguration();
        services.AddHttpContextAccessor();
        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });
        //JWT Authorization role ADMIN
        services.AddAuthentication();
      
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        services.AddSingleton<IAuthorizationHandler, JWTTokenRequirementHandle>();

        //Proxy client
        services.RegisterProxyClientService();

        var root = builder.Configuration.Build();
        //Log.Logger = new LoggerConfiguration()
        //    .Enrich.WithProperty("app_name", Assembly.GetEntryAssembly().GetName().Name)
        //    .Enrich.WithProperty("app_port", Environment.GetEnvironmentVariable("APP_PORT") ?? string.Empty)
        //    .WriteTo.Elasticsearch(ConfigureElasticSink(root))
        //    .ReadFrom.Configuration(configuration)
        //    .CreateLogger();
        //services.AddSingleton(Log.Logger);

    }

    public static void RegisterProxyClientService(this IServiceCollection services)
    {
        
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
