using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpPkgallocRemove
{
    public string Sonum { get; set; }

    public string Cpncode { get; set; }

    public string CpnDesc { get; set; }

    public decimal? Wuqty { get; set; }

    public string Imcode { get; set; }

    public string Imdesc { get; set; }

    public decimal? Imalloc { get; set; }

    public decimal? AdjQty { get; set; }

    public decimal? AdjInAlloc { get; set; }

    public int? Sostatus { get; set; }

    public DateTime? DueDate { get; set; }

    public string Customername { get; set; }
}
