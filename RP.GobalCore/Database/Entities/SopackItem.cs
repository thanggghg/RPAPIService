using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SopackItem
{
    public int SopkgItemPk { get; set; }

    public int SoheaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int OrderId { get; set; }

    public string PkgImcode { get; set; }

    public string ItemCode { get; set; }

    public decimal Bomqty { get; set; }

    public decimal? ItemQty { get; set; }

    public string ItemDesc { get; set; }

    public bool? IsFg { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public decimal? UnitQty { get; set; }

    public string Notes { get; set; }

    public int? SopodetailId { get; set; }
}
