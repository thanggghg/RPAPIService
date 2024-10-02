using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Rmmanufacture
{
    public int RmmanufacturePk { get; set; }

    public string Rmcode { get; set; }

    public string MfgName { get; set; }

    public virtual RawMaterial RmcodeNavigation { get; set; }
}
