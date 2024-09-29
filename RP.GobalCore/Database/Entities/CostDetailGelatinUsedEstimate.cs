using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailGelatinUsedEstimate
{
    public string MachineType { get; set; }

    public decimal GelThickness { get; set; }

    public decimal Rpm { get; set; }

    public decimal RunKgPerHour { get; set; }

    public decimal? PctGelLost { get; set; }
}
