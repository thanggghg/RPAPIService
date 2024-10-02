using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class DevicePhyInvByLocation
{
    public int DeviceLocNoPk { get; set; }

    public string Sku { get; set; }

    public int Unit { get; set; }

    public int QtyPerUnit { get; set; }

    public int? TotalQty { get; set; }

    public string Location { get; set; }

    public string SerialNumber { get; set; }

    public string AssetNo { get; set; }

    public string PhoneNumber { get; set; }

    public string Reason { get; set; }

    public string Notes { get; set; }

    public DateOnly? ReturnDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
