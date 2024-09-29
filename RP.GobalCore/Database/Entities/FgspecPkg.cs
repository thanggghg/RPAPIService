using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecPkg
{
    public int FgspecPkgNoPk { get; set; }

    public int FgspecHeaderNoFk { get; set; }

    public byte RecStatusNoFk { get; set; }

    public string FormField { get; set; }

    public string FieldSpec { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
