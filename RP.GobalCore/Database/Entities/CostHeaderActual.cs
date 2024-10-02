using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostHeaderActual
{
    public int ActualHdrPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Brlot { get; set; }

    public string Imcode { get; set; }

    public decimal? EstBulkPerThousand { get; set; }

    public decimal? EstBulkLaborPerThousand { get; set; }

    public decimal? EstBulkOvrHdPerThousand { get; set; }

    public decimal? EstGelPerThousand { get; set; }

    public decimal? EstGelLaborPerThousand { get; set; }

    public decimal? EstCoatPerThousand { get; set; }

    public decimal? EstCoatLaborPerThousand { get; set; }

    public decimal? EstEmptyCapPerThousand { get; set; }

    public decimal? EstEmptyCapLaborPerThousand { get; set; }

    public decimal? ActBulkYieldPct { get; set; }

    public decimal? ActBulkPerThousand { get; set; }

    public decimal? ActBulkLaborPerThousand { get; set; }

    public decimal? ActBulkOvrHdPerThousand { get; set; }

    public decimal? ActGelPerThousand { get; set; }

    public decimal? ActGelLaborPerThousand { get; set; }

    public decimal? ActCoatPerThousand { get; set; }

    public decimal? ActCoatLaborPerThousand { get; set; }

    public decimal? ActEmptyCapPerThousand { get; set; }

    public decimal? ActEmptyCapLaborPerThousand { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual ICollection<CostDetailLaborActual> CostDetailLaborActuals { get; set; } = new List<CostDetailLaborActual>();

    public virtual ICollection<CostDetailOverHeadActual> CostDetailOverHeadActuals { get; set; } = new List<CostDetailOverHeadActual>();
}
