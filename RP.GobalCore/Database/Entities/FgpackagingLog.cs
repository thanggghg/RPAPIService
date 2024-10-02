using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgpackagingLog
{
    public string FgplpackagingNumber { get; set; }

    public int FgplrmproductTypeNoFk { get; set; }

    public int FgplitemMasterNoFk { get; set; }

    public int? FgplrawMaterialNoFk { get; set; }

    public string FgplcustomerNoFk { get; set; }

    public double? FgplrmqtyPer1000 { get; set; }

    public string FgplentryOrdered { get; set; }

    public int? FgpltypeNoFk { get; set; }

    public string Fgplrmcode { get; set; }

    public string Fgplrmdesc { get; set; }

    public string Fgplnotes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public bool? IsFg { get; set; }

    public decimal? PackagingItemQty { get; set; }
}
