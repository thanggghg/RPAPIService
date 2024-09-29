using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecImtrackingHdrLog
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
}
