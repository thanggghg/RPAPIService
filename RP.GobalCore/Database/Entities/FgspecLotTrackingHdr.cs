using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecLotTrackingHdr
{
    public int LotIdPk { get; set; }

    public int SpecIdFk { get; set; }

    public string Brlot { get; set; }

    public DateTime? MfgDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool LotCompleted { get; set; }

    public string Comments { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual ICollection<FgspecLotTrackingDetail> FgspecLotTrackingDetails { get; set; } = new List<FgspecLotTrackingDetail>();

    public virtual FgspecImtrackingHdr SpecIdFkNavigation { get; set; }
}
