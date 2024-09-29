using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingResultDetail
{
    public int RmtResPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmthFk { get; set; }

    public int? RmtOrder { get; set; }

    public string RmtTest { get; set; }

    public string RmtMethod { get; set; }

    public string RmtResultSpecification { get; set; }

    public double? RmtResultValue { get; set; }

    public string RmtResult { get; set; }

    public string RmtResultUnit { get; set; }

    public string RmtResultComment { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
