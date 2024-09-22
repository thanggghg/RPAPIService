using System.Globalization;
using GoSell.Library.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

namespace GoSell.Library.Extensions.Localization
{
    public static class LocalizationExtensions
    {
        public static void AddLocalizationExtension(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton<LocalizationMiddleware>();
            services.AddDistributedMemoryCache();
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddScoped<ILocalizationService, LocalizationService>();
        }

        public static void AddLocalizationConfigure(this WebApplication app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("vi")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();
            app.UseMiddleware<LocalizationMiddleware>();
        }
    }
}
