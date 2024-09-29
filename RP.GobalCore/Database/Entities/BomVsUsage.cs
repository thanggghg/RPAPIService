using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BomVsUsage
{
    public string Rmcode { get; set; }

    public string Rmdescription { get; set; }

    public double? RmallocQty { get; set; }

    public decimal? RmallocSubQty { get; set; }

    public decimal? Wuqty { get; set; }

    public int? LastPurPrice { get; set; }

    public double? AdjAlloc { get; set; }

    public decimal DisplayOrder { get; set; }

    public decimal RmqtyOh { get; set; }

    public decimal RmqtyOrdered { get; set; }

    public double? RmqtyAllocated { get; set; }

    public decimal RmqtyInQcinspection { get; set; }

    public string BrlotNum { get; set; }

    public int BrlotStatus { get; set; }

    public int? Sonum { get; set; }

    public int Sostatus { get; set; }

    public string Imcode { get; set; }

    public string CustomerName { get; set; }

    public DateTime Sodate { get; set; }

    public DateTime? SohdueDate { get; set; }

    public string ItemClass { get; set; }
}
