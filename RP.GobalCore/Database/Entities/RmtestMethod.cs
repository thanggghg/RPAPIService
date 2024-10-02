using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmtestMethod
{
    public int RmtestMethodPk { get; set; }

    public string TestCode { get; set; }

    public string TestDesc { get; set; }

    public string MethodClass { get; set; }

    public string Uom { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
