using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecReceivingRemove
{
    public string Vendor { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public string Po { get; set; }

    public string NewPos { get; set; }

    public string ItemCode { get; set; }

    public double? Box { get; set; }

    public double? QtyBox { get; set; }

    public double? RecQty { get; set; }

    public string VendorLot { get; set; }

    public string OldWhsLot { get; set; }

    public string NewWhslot { get; set; }

    public DateTime? PoDate { get; set; }

    public string F13 { get; set; }
}
