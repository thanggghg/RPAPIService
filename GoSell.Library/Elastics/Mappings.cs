using Nest;

namespace GoSell.Library.Elastics
{
    public static class Mappings
    {
        public static void BuildElasticMapping<T>(ConnectionSettings setting) where T : class
        {
            setting.DefaultMappingFor<T>(m => m.IndexName(nameof(T)));
        }
    }
}
