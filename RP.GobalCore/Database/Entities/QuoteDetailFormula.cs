using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteDetailFormula
{
    public int QuoteFormulaNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool QfformulaGelatin { get; set; }

    public int QfquoteHeaderNoFk { get; set; }

    public int QfquoteDetailNoFk { get; set; }

    public int QfmlSortId { get; set; }

    public int? QfrnDformulaNoFk { get; set; }

    public string QfrnDformulaCode { get; set; }

    public decimal? QfrnDformulaCodeVer { get; set; }

    public int? QfgelItemMasterNoFk { get; set; }

    public int? QfgelFormulaNoFk { get; set; }

    public int? QfrmitemNoFk { get; set; }

    public string QfrmitemCode { get; set; }

    public string Qfrmdesc { get; set; }

    public string QflabelClaim { get; set; }

    public double? QfunitRmwt { get; set; }

    public double? QfpctOver { get; set; }

    public double? QfrmtotalWt { get; set; }

    public string Qfspec { get; set; }

    public int? QfitemMasterNoFk { get; set; }

    public string QfitemMasterCode { get; set; }

    public decimal? QfitemMasterVer { get; set; }

    public string QfitemMasterDesc { get; set; }

    public string Qfmethod { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
