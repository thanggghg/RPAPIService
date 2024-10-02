using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingMd
{
    public int RmtMdPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? RmtMdOrder { get; set; }

    public int? RmtMdProductClass { get; set; }

    public int? RmtMdTestType { get; set; }

    public int? RmtMdMethodFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
