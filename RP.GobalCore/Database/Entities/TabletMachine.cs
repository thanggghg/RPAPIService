using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TabletMachine
{
    public int TabletMachinePk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string TabletMachineName { get; set; }

    public int? TabletMachineLowRate { get; set; }

    public int? TabletMachineHighRate { get; set; }

    public int? TabletMachineLineNumber { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
