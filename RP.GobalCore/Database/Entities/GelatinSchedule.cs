using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GelatinSchedule
{
    public int GelSchedNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string MachineName { get; set; }

    public string Gblot { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Notes { get; set; }

    public bool SchedDone { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
