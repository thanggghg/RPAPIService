using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GlrevenueSubAccount
{
    public string GlrevSubAcctNoPk { get; set; }

    public string GlrevAcctNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string GlrevSubAcctName { get; set; }

    public int? GlrevSubAcctProductClassNoFk { get; set; }

    public int GlrevSubAcctProdTypeNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
