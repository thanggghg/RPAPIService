using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Device
{
    public string Sku { get; set; }

    public string DeviceName { get; set; }

    public string DeviceType { get; set; }

    public int DeviceStatus { get; set; }

    public string MfgName { get; set; }

    public string Model { get; set; }

    public string Processor { get; set; }

    public string Memory { get; set; }

    public string StorageGb { get; set; }

    public string Compatibility { get; set; }

    public int DeviceOhqty { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? IsConsumable { get; set; }

    public byte[] Image { get; set; }
}
