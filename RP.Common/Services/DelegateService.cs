namespace RP.Common.Services
{
    public class DelegateService
    {
        public delegate T SocialServiceResolver<T>(string key) where T : class;
        public delegate T ExportDataMapperResolver<T>(string key) where T : class;
    }
}
