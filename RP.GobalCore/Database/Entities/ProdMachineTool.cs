using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProdMachineTool
{
    public string MachineToolId { get; set; }

    public string ToolSize { get; set; }

    public decimal OutputAvgPerHr { get; set; }
}
