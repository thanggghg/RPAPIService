using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Soformula
{
    public int SoformulaNoPk { get; set; }

    public int? FormulaNoFk { get; set; }

    public string OrigFormulaNumber { get; set; }

    public string FormulaNumber { get; set; }

    public int? QuoteHeaderNumberFk { get; set; }

    public int? QuoteDetailNoFk { get; set; }

    public int? SoheaderNoFk { get; set; }

    public int? SodetailNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool FormulaGelatin { get; set; }

    public int FormulaItemMasterNoFk { get; set; }

    public string SormitemNo { get; set; }

    public string Sormdescription { get; set; }

    public int FormulaRawMaterialNoFk { get; set; }

    public string FormulaRmcustomerNoFk { get; set; }

    public int? FormulaUomnoFk { get; set; }

    public double FormulaRmqty { get; set; }

    public string FormulaLabelClaim { get; set; }

    public double? FormulaPercentQty { get; set; }

    public double? FormulaPercentOver { get; set; }

    public double? FormulaPercentDailyValue { get; set; }

    public int FormulaEntryOrdered { get; set; }

    public string SoformulaNotes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? ShellItemMasterNoFk { get; set; }

    public decimal? Bomqty { get; set; }

    public decimal? ItemQty { get; set; }
}
