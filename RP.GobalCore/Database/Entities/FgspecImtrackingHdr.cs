using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecImtrackingHdr
{
    public int SpecIdPk { get; set; }

    public string Imcode { get; set; }

    public string Imdesc { get; set; }

    public string Imver { get; set; }

    public int? SpecVer { get; set; }

    public string ApproveBy { get; set; }

    public DateTime? ApproveDt { get; set; }

    public string Comments { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual ICollection<FgspecImtrackingDetail> FgspecImtrackingDetails { get; set; } = new List<FgspecImtrackingDetail>();

    public virtual ICollection<FgspecLotTrackingHdr> FgspecLotTrackingHdrs { get; set; } = new List<FgspecLotTrackingHdr>();
}
