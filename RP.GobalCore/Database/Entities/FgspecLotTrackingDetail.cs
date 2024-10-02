using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecLotTrackingDetail
{
    public int LotTestIdPk { get; set; }

    public string Brlot { get; set; }

    public int SpecTestIdFk { get; set; }

    public string TestResult { get; set; }

    public string TestBy { get; set; }

    public string BookNpage { get; set; }

    public DateTime? TestDate { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual FgspecLotTrackingHdr BrlotNavigation { get; set; }
}
