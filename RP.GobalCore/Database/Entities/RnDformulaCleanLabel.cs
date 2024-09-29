using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDformulaCleanLabel
{
    public int FmlCleanLabelPk { get; set; }

    public int FmlHdrFk { get; set; }

    public string CleanLabelDesc { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
