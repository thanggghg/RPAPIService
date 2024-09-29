using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmppkgAllocRemove1
{
    public int? Sonum { get; set; }

    public string CpnCode { get; set; }

    public string CpnDesc { get; set; }

    public decimal? Wuqty { get; set; }

    public string Imcode { get; set; }

    public string Imdesc { get; set; }

    public decimal? Imalloc { get; set; }

    public decimal? AdjOrg { get; set; }

    public decimal? AddInAlloc { get; set; }

    public int? Sohstatus { get; set; }

    public DateTime? DueDate { get; set; }

    public string Customer { get; set; }
}
