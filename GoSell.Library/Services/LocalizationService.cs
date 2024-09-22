using Microsoft.Extensions.Localization;

namespace GoSell.Library.Services
{
    public partial class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<LocalizationService> _localizer;
        public LocalizationService(IStringLocalizer<LocalizationService> localizer)
        {
            _localizer = localizer;
        }

        public string GetResourceAsync(string resourceKey, string defaultValue = "")
        {
            var localized = _localizer[resourceKey];
            return !string.IsNullOrEmpty(localized?.Value) && !localized.ResourceNotFound ? localized.Value : (!string.IsNullOrEmpty(defaultValue) ? defaultValue : resourceKey);
        }
    }
}
