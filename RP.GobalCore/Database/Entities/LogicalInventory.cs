using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class LogicalInventory
{
    public string ItemCode { get; set; }

    public string WhsLot { get; set; }

    public decimal Ohqty { get; set; }

    public string ItemDesc { get; set; }

    public string ItemClass { get; set; }

    public decimal RmqtyAllocated { get; set; }

    public decimal? PhyQty { get; set; }

    public string VendorName { get; set; }
}
