using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fgpackaging
{
    public int PackagingNoPk { get; set; }

    public string PackagingNumber { get; set; }

    public int PackagingRmproductTypeNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int PackagingItemMasterNoFk { get; set; }

    public int? PackagingRawMaterialNoFk { get; set; }

    public string PackagingCustomerNoFk { get; set; }

    public double? PackagingRmqtyPer1000 { get; set; }

    public string PackagingEntryOrdered { get; set; }

    public int? PackagingTypeNoFk { get; set; }

    public string PackagingRmcode { get; set; }

    public string PackagingRmdesc { get; set; }

    public string PackagingNotes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public bool? IsFg { get; set; }

    public decimal? PackagingItemQty { get; set; }
}
