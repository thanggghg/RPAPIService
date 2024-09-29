using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpRmallocRemove
{
    public string Rmcode { get; set; }

    public string Brlot { get; set; }

    public string Sonum { get; set; }

    public string ProdDesc { get; set; }

    public string ProdCode { get; set; }

    public DateTime? DueDate { get; set; }

    public string CustomerName { get; set; }

    public decimal? AllocQty { get; set; }

    public decimal? AdjAlloc { get; set; }

    public decimal? Wuqty { get; set; }

    public bool? Brcompleted { get; set; }

    public decimal? SysAlloc { get; set; }

    public string Rmdesc { get; set; }
}
