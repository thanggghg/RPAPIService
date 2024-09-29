using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmactivationRequest
{
    public int RanoPk { get; set; }

    public string Rmcode { get; set; }

    public int Status { get; set; }

    public string Reason { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
