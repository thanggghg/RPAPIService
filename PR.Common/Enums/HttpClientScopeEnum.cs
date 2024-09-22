using System.ComponentModel;

namespace GoSell.Common.Enums
{
    public enum HttpClientScopeEnum
    {
        [Description("Order Services")]
        ORDER,
        [Description("Analysis Services")]
        ANALYSIS,
        [Description("Social Services")]
        SOCIAL,
        [Description("Affiliate Authentication Services")]
        AFFILIATE_AUTHENTICATION,
    }
}
