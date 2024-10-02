using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProdMachine
{
    public string MachineName { get; set; }

    public string MachineDesc { get; set; }

    public string ProdDept { get; set; }

    public string ProdLocation { get; set; }

    public int? RecStatusNoFk { get; set; }

    public int OrderId { get; set; }

    public string MachineToolId { get; set; }

    public decimal? OutputAvgPerHr { get; set; }

    public string ToolSize { get; set; }

    public decimal? Rpm { get; set; }

    public string Notes { get; set; }
}
