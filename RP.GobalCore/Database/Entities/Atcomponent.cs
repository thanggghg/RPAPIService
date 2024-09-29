using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Atcomponent
{
    public int AtcpnId { get; set; }

    public int AppTreeFk { get; set; }

    public string AtcpnName { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
