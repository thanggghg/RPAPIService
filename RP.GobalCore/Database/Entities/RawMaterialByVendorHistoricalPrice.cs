using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialByVendorHistoricalPrice
{
    public int RawMaterialVendorHistoricalPriceNoPk { get; set; }

    public DateTime RmvhpchangeDate { get; set; }

    public string RmvhpchangeBy { get; set; }

    public int RmvhprawMaterialNoFk { get; set; }

    public string RmvhpcustomerNoFk { get; set; }

    public int RmvhpvendorNoFk { get; set; }

    public string RmvhprawMaterialItemNumber { get; set; }

    public decimal Rmvhppack { get; set; }

    public int RecStatusNoFk { get; set; }

    public double RmvhppriceOld { get; set; }

    public double RmvhppriceNew { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public string CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? RmvoldMinQty { get; set; }

    public decimal? RmvnewMinQty { get; set; }

    public decimal? RmvquoteQtyOld { get; set; }

    public decimal? RmvquoteQtyNew { get; set; }

    public string Rmvquoteby { get; set; }

    public string RmvquoteNote { get; set; }
}
