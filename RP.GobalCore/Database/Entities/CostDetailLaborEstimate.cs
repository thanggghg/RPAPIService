using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailLaborEstimate
{
    public int CostDetailLaborNoPk { get; set; }

    public int CdlcostHeaderNoFk { get; set; }

    public int CdlworkTypeNoFk { get; set; }

    public int CdlworkTaskCategoryNoFk { get; set; }

    public string CdlworkTaskName { get; set; }

    public int RecStatusNoFk { get; set; }

    public double CdlmachineHrs { get; set; }

    public double CdlmachineRates { get; set; }

    public double CdlmachineCost { get; set; }

    public double CdllaborHrs { get; set; }

    public double CdllaborRates { get; set; }

    public double CdllaborCost { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
