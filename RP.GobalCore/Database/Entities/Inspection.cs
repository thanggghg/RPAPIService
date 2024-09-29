using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Inspection
{
    public int InspectionId { get; set; }

    public int RecStatusNoFk { get; set; }

    public DateTime? InspectionDate { get; set; }

    public string InspectionTeam { get; set; }

    public string InspectionInspector { get; set; }

    public string InspectionLot { get; set; }

    public int? InspectionTrays { get; set; }

    public int? InspectionDeeps { get; set; }

    public string InspectionDefect { get; set; }

    public int? InspectionDefectCount { get; set; }

    public string InspectionComment { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
