using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecDupLotRemove
{
    public DateTime? ReceivedDate { get; set; }

    public string ItemCode { get; set; }

    public string Po { get; set; }

    public string CorrectLot { get; set; }

    public string CurrentLot { get; set; }

    public double? RecvQty { get; set; }

    public string VendorLot { get; set; }

    public string Vendor { get; set; }
}
