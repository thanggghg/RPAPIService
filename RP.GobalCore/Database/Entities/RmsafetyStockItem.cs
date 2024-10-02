using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmsafetyStockItem
{
    public string ItemCode { get; set; }

    public double MinimumQty { get; set; }

    public string Remarks { get; set; }

    public int RecStatusNoFk { get; set; }
}
