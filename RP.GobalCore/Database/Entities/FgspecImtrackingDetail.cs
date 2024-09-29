using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecImtrackingDetail
{
    public int SpecTestIdPk { get; set; }

    public int SpecIdFk { get; set; }

    public string Analysis { get; set; }

    public string Specification { get; set; }

    public string Method { get; set; }

    public string Comments { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual FgspecImtrackingHdr SpecIdFkNavigation { get; set; }
}
