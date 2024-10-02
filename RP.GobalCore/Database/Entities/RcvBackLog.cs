using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvBackLog
{
    public int RcvBackLogsNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RcvBlstatusNoFk { get; set; }

    public string RcvBlwhsLot { get; set; }

    public int? RcvBlassignedDeptNoFk { get; set; }

    public string RcvBlassignedName { get; set; }

    public DateTime? RcvBlexpectedDt { get; set; }

    public string RcvBlnotes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public byte[] Picture { get; set; }
}
