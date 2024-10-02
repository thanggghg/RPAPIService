using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InventoryAging
{
    public string Itemcode { get; set; }

    public string WhsLot { get; set; }

    public string Brlot { get; set; }

    public decimal RemainQty { get; set; }

    public int? MonthOnShelf { get; set; }

    public int? DayOnShelf { get; set; }

    public string CustomerName { get; set; }

    public string VendorName { get; set; }

    public DateTime? ExpDt { get; set; }

    public decimal? RcvQty { get; set; }

    public int? UnitCost { get; set; }

    public decimal? AllocQty { get; set; }

    public string ItemDesc { get; set; }

    public string ItemClass { get; set; }
}
