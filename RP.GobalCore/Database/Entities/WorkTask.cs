using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class WorkTask
{
    public int WorkTaskNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string WttaskName { get; set; }

    public int WttaskCategoryNoFk { get; set; }

    public int WttaskTypeNoFk { get; set; }

    public decimal WttaskMachineRate { get; set; }

    public decimal WttaskLaborRate { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
