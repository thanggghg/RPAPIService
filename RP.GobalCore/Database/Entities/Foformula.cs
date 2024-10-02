using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Foformula
{
    public int FoformulaNoPk { get; set; }

    public int? QuoteHeaderNumberFk { get; set; }

    public int? QuoteDetailNoFk { get; set; }

    public int? FoheaderNoFk { get; set; }

    public int? FodetailNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool FormulaGelatin { get; set; }

    public int FormulaItemMasterNoFk { get; set; }

    public string FormitemNo { get; set; }

    public string Formdescription { get; set; }

    public int FormulaRawMaterialNoFk { get; set; }

    public string FormulaRmcustomerNoFk { get; set; }

    public int? FormulaUomnoFk { get; set; }

    public double FormulaRmqty { get; set; }

    public string FormulaLabelClaim { get; set; }

    public double? FormulaPercentQty { get; set; }

    public double? FormulaPercentOver { get; set; }

    public double? FormulaPercentDailyValue { get; set; }

    public int FormulaEntryOrdered { get; set; }

    public string FoformulaNotes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? ShellItemMasterNoFk { get; set; }
}
