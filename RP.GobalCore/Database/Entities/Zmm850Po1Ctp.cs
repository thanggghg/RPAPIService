using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Po1Ctp
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string Ctppo { get; set; }

    public DateTime? CtppoDate { get; set; }

    public string CtppoitemLineNumber { get; set; }

    public string Ctp01ClassOfTradeCd { get; set; }

    public string Ctp02PriceIdc { get; set; }

    public double? Ctp03UnitPrice { get; set; }

    public double? Ctp04Qty { get; set; }

    public string Ctpc001Uomcd { get; set; }

    public string Ctp06PriceMultiplierQ { get; set; }

    public double? Ctp07Multiplier { get; set; }

    public double? Ctp08Amt { get; set; }

    public string Ctp09UnitPriceCd { get; set; }

    public string Ctp10ConditionValue { get; set; }

    public int? Ctp11MultiplePriceQty { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
