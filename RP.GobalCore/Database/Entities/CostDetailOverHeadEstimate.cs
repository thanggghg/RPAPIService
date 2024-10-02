using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailOverHeadEstimate
{
    public int CostDetailOverHeadNoPk { get; set; }

    public int CdohcostHeaderNoFk { get; set; }

    public bool CdohdirectFlag { get; set; }

    public string CdohmetaDataName { get; set; }

    public int RecStatusNoFk { get; set; }

    public double CdohpercentOfBulkCost { get; set; }

    public double CdohratesPer1000 { get; set; }

    public string CdohorderEntry { get; set; }

    public double? CdohratesPerKg { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
