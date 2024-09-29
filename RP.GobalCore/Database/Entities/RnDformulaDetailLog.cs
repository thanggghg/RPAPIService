using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDformulaDetailLog
{
    public int RnDlogDetailNoPk { get; set; }

    public int RnDformulaDetailNoPk { get; set; }

    public int RnDfdheaderNoFk { get; set; }

    public int? RnDfdrmitemFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RnDfdsortId { get; set; }

    public string RnDfdrmitemCode { get; set; }

    public string RnDfdrmitemDesc { get; set; }

    public string RnDfdlabelClaim { get; set; }

    public decimal? RnDfdunitWt { get; set; }

    public decimal? RnDfdpctOver { get; set; }

    public decimal? RnDfdpctOverA { get; set; }

    public decimal? RnDfdtotalWt { get; set; }

    public string RnDfdspec { get; set; }

    public string RnDfdmethod { get; set; }

    public string RnDfdremarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public decimal? RnDfdpctPotency { get; set; }

    public decimal? RnDfdmwratio { get; set; }
}
