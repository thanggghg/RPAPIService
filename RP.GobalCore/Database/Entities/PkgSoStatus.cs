using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PkgSoStatus
{
    public int Sonum { get; set; }

    public string Ponum { get; set; }

    public string Sostatus { get; set; }

    public bool? SohstockItem { get; set; }

    public DateTime Sodate { get; set; }

    public DateTime? BulkConfirmDt { get; set; }

    public DateTime? PkgConfirmDt { get; set; }

    public DateTime? PkgBomdt { get; set; }

    public DateTime? SodueDt { get; set; }

    public DateTime? ReqDate { get; set; }

    public DateTime? PostDate { get; set; }

    public string Imcode { get; set; }

    public float? PackSize { get; set; }

    public string Uom { get; set; }

    public double? Imqty { get; set; }

    public string PackWhsLoc { get; set; }

    public string Imdesc { get; set; }

    public int? BatchNum { get; set; }

    public decimal? PostQty { get; set; }

    public double? RemainQty { get; set; }

    public string Brlot { get; set; }

    public DateTime? BrblendDt { get; set; }

    public string Csrep { get; set; }

    public string CustomerName { get; set; }

    public int? EstimatePackQty { get; set; }

    public int? PostNum { get; set; }

    public DateTime? PkgSchedReadyDt { get; set; }

    public DateTime? PkgSchedRecvDt { get; set; }

    public bool? BatchDone { get; set; }

    public string PostStatus { get; set; }
}
