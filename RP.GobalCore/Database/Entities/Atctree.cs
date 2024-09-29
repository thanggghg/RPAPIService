using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Atctree
{
    public int AtcpnId { get; set; }

    public string TitleId { get; set; }

    public bool Permission { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
