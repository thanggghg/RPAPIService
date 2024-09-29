using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailOverHeadActual
{
    public int ActualOverHeadNoPk { get; set; }

    public int ActualHeaderNoFk { get; set; }

    public bool DirectFlag { get; set; }

    public string MetaDataName { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal PercentOfBulkCost { get; set; }

    public decimal RatesPer1000 { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual CostHeaderActual ActualHeaderNoFkNavigation { get; set; }
}
