using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Batch
{
    public int BatchNoPk { get; set; }

    public int BatchTypeNoFk { get; set; }

    public int BatchStatusNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string BatchNotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
