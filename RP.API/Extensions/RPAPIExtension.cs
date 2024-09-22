internal static class RPAPIExtension
{
    public static void AddAffiliateTrackingServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
      
    }

    public static void AddAffiliatePublisherManagementServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;
    }
}
