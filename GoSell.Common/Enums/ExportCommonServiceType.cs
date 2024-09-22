using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSell.Common.Enums
{
    public enum ExportCommonServiceType
    {
        [Description("cashbook")]
        cashbook,
        [Description("affiliateOrderCommissionReport")]
        affiliateOrderCommissionReport,
        [Description("affiliateUrlReport")]
        affiliateUrlReport,
    }
}
