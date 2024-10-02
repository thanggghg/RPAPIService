using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgpkgComponentLog
{
    public int FgpkgCpnLognoPk { get; set; }

    public int FgpkgCpnNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int ItemMasterNoFk { get; set; }

    public string CpnCode { get; set; }

    public decimal CnpQty { get; set; }

    public string CpnDesc { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public bool? IsFg { get; set; }
}
