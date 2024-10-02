using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingType
{
    public int PackagingNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int Pkgtype { get; set; }

    public string PkgtypeDesc { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
