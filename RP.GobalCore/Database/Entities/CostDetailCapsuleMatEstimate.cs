using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailCapsuleMatEstimate
{
    public int CostDetailCapsuleMatNoPk { get; set; }

    public int CdcmsocapsulingNoFk { get; set; }

    public string CdcmcapsulingNumber { get; set; }

    public int CdcmquoteHeaderNoFk { get; set; }

    public int? CdcmsoheaderNoFk { get; set; }

    public int CdcmcostHeaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int CdcmitemMasterNoFk { get; set; }

    public int CdcmrawMaterialNoFk { get; set; }

    public string CdcmrmitemNumber { get; set; }

    public double Cdcmrmqty { get; set; }

    public double CdcmunitCost { get; set; }

    public double CdcmextendedCost { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? CdcmshellItemMasterNoFk { get; set; }

    public decimal? Moqcharge { get; set; }
}
