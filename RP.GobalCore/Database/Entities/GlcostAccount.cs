using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GlcostAccount
{
    public string GlcostAcctNoPk { get; set; }

    public string GlcostCtrNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string GlcostAcctName { get; set; }

    public int? GlcostAcctProdClass { get; set; }

    public int? GlcostAcctProdType { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
