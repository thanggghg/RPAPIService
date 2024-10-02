using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PillDiceCavity
{
    public int PillDiceCavityNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int PdccavitiesPerRound { get; set; }

    public int PdcroundPerDice { get; set; }

    public double? PillSize { get; set; }

    public string ShapeCode { get; set; }

    public string ShapeType { get; set; }

    public string PdcsortedX { get; set; }

    public string PdcsortedY { get; set; }

    public string ReMarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public byte[] Picture { get; set; }
}
