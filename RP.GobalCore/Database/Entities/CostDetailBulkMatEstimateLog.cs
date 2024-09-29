using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailBulkMatEstimateLog
{
    public int CdbmlogPk { get; set; }

    public int CostDetaiBulkMatlNoPk { get; set; }

    public int CdbmcostHeaderNoFk { get; set; }

    public int CdbmrawMaterialNoFk { get; set; }

    public string CdbmrmitemNumber { get; set; }

    public string Cdrmdescription { get; set; }

    public int RecStatusNoFk { get; set; }

    public double CdbmweightPerThousand { get; set; }

    public double CdbmcostPerKilogram { get; set; }

    public double CdbmcostPerThousand { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
