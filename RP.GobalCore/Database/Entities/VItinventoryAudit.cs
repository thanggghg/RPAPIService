using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class VItinventoryAudit
{
    public string Sku { get; set; }

    public string DeviceName { get; set; }

    public int LogQty { get; set; }

    public int? PhyQty { get; set; }

    public int ItkeepQty { get; set; }

    public int UserKeepQty { get; set; }
}
