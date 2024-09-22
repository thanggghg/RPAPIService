namespace RP.Library.Services
{
    public partial interface ILocalizationService
    {
        string GetResourceAsync(string resourceKey, string defaultValue = "");
    }
}
