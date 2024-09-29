using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingUsageBrpdflog
{
    public int PkgBrpdfNoPk { get; set; }

    public int PkgUsedHeaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string UserIdnoFk { get; set; }

    public bool IsModified { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
