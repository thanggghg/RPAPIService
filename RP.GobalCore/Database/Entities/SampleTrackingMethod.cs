using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingMethod
{
    public int RmtMethodPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmtMethodTest { get; set; }

    public string RmtMethod { get; set; }

    public string RmtMethodDescr { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
