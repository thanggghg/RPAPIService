using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuotePkgCostDetailEstimateLog
{
    public int QpcostDetailLogPk { get; set; }

    public int QpcostDetailPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int QpcostHdrFk { get; set; }

    public int? QuoteBulkHdrFk { get; set; }

    public decimal? YieldPct { get; set; }

    public decimal? ProfitPct { get; set; }

    public int? ProfitLevel { get; set; }

    public bool LevelSelect { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? CpnCost { get; set; }

    public decimal? BulkCost { get; set; }

    public string Remark { get; set; }
}
