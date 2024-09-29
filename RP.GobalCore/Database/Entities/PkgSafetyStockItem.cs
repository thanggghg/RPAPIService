using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PkgSafetyStockItem
{
    public string ItemCode { get; set; }

    public double MinimumQty { get; set; }

    public string Notes { get; set; }

    public int RecStatusNoFk { get; set; }
}
