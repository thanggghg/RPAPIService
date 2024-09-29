using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SopackStatusOpen
{
    public int? Sonum { get; set; }

    public string Imcode { get; set; }

    public DateTime Sodt { get; set; }

    public double? OrderQty { get; set; }

    public DateTime? Bomdt { get; set; }

    public int PkgNum { get; set; }

    public DateTime PkgCreateDt { get; set; }

    public DateTime? PkgSchedReadyDt { get; set; }

    public DateTime? PkgSchedRecvDt { get; set; }

    public DateTime? PkgPostDt { get; set; }
}
