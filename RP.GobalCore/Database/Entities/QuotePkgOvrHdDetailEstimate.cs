using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuotePkgOvrHdDetailEstimate
{
    public int QpovrHdDetailPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int QpovrHdHdrFk { get; set; }

    public string Task { get; set; }

    public decimal? Hours { get; set; }

    public decimal? UnitProduced { get; set; }

    public decimal? CostPerHour { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual QuotePkgHeader QpovrHdHdrFkNavigation { get; set; }
}
