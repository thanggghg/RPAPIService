using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fgformula
{
    public int FormulaNoPk { get; set; }

    public string FormulaNumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool FormulaGelatin { get; set; }

    public int FormulaItemMasterNoFk { get; set; }

    public int? FormulaRawMaterialNoFk { get; set; }

    public string RmitemNo { get; set; }

    public string Rmdescription { get; set; }

    public string FormulaRmcustomerNoFk { get; set; }

    public int? FormulaUomnoFk { get; set; }

    public double? FormulaRmqty { get; set; }

    public string FormulaLabelClaim { get; set; }

    public double? FormulaPercentQty { get; set; }

    public double? FormulaPercentOver { get; set; }

    public double? FormulaPercentDailyValue { get; set; }

    public int FormulaEntryOrdered { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? ShellItemMasterNoFk { get; set; }
}
