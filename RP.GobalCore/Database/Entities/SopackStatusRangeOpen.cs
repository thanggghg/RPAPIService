using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SopackStatusRangeOpen
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

    public int? BomPkgBatchCreate { get; set; }

    public int? PkgBatchCreateSchedReady { get; set; }

    public int? SchedReadyPkgRecv { get; set; }

    public int? PkgRecvPkgPost { get; set; }

    public int? BomPkgPost { get; set; }
}
