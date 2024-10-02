using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InventoryTransHistory
{
    public int InvTransHisId { get; set; }

    public string Rmcode { get; set; }

    public string Imcode { get; set; }

    public string WhsLot { get; set; }

    public string Brlot { get; set; }

    public int? Sonum { get; set; }

    public decimal? CurOhqty { get; set; }

    public decimal? CurOnOrderQty { get; set; }

    public decimal? CurAllocQty { get; set; }

    public decimal? CurQcqty { get; set; }

    public decimal? CurShipQty { get; set; }

    public decimal? IssueOhqty { get; set; }

    public decimal? IssueOnOrderQty { get; set; }

    public decimal? IssueAllocQty { get; set; }

    public decimal? IssueQcqty { get; set; }

    public decimal? IssueShipQty { get; set; }

    public string Source { get; set; }

    public string Reason { get; set; }

    public string IssueFrom { get; set; }

    public string IssueByUser { get; set; }

    public DateTime IssueDate { get; set; }

    public string Ponum { get; set; }

    public decimal? CurExpiredQty { get; set; }

    public decimal? IssueExpiredQty { get; set; }
}
