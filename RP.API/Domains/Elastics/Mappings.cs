using Nest;

namespace RP.API.Domains.Elastics
{
    public static class Mappings
    {
        public static void BuildElasticMapping(ConnectionSettings setting)
        {
            setting.DefaultMappingFor<GosellOrderModel>(m => m.IndexName("gosell_order"));
        }
    }
}
