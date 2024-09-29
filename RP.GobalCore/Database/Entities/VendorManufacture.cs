using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class VendorManufacture
{
    public int VendorManufacturePk { get; set; }

    public int VendorNoFk { get; set; }

    public int MfrFk { get; set; }
}
