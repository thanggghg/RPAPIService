using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailGelatinMatEstimate
{
    public int CostDetailGelatinMatNoPk { get; set; }

    public int CdgmsogelatingNoFk { get; set; }

    public int? CdgmsoheaderNoFk { get; set; }

    public int CdgmquoteHeaderNoFk { get; set; }

    public int CdgmcostHeaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int CdgmitemMasterNoFk { get; set; }

    public int CdgmrawMaterialNoFk { get; set; }

    public string CdgmrmitemNumber { get; set; }

    public double? CdgmpercentageQtyPerKg { get; set; }

    public double? CdgmrmqtyPerHourPerKg { get; set; }

    public double CdgmrmcostPerKg { get; set; }

    public double CdgmextendedCost { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public decimal? Moqcharge { get; set; }
}
