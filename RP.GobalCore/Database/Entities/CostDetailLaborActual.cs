using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailLaborActual
{
    public int ActualLaborNoPk { get; set; }

    public int ActualHeaderNoFk { get; set; }

    public int WorkTypeNoFk { get; set; }

    public int WorkTaskCategoryNoFk { get; set; }

    public string WorkTaskName { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal MachineHrs { get; set; }

    public decimal MachineRates { get; set; }

    public decimal MachineCost { get; set; }

    public decimal LaborHrs { get; set; }

    public decimal LaborRates { get; set; }

    public decimal LaborCost { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual CostHeaderActual ActualHeaderNoFkNavigation { get; set; }
}
