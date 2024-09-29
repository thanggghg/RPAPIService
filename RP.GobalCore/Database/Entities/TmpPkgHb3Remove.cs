using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpPkgHb3Remove
{
    public string ItemCode { get; set; }

    public string WhsLot { get; set; }

    public decimal? PerBox { get; set; }

    public decimal? Boxes { get; set; }
}
