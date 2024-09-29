using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecRmphySflRemove
{
    public string ItemCode { get; set; }

    public string CustCode { get; set; }

    public string WhsLot { get; set; }

    public string Warehouse { get; set; }

    public DateTime? RcvDate { get; set; }

    public DateTime? ExpDate { get; set; }

    public double? Boxes { get; set; }

    public double? QtyBox { get; set; }

    public double? TotalQty { get; set; }

    public string RackLoc { get; set; }

    public string PalletId { get; set; }

    public string Reason { get; set; }

    public string VendorLot { get; set; }

    public string VendorName { get; set; }
}
