using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GlcostCenter
{
    public string GlcostCtrNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string GlcostCtrName { get; set; }

    public int GlcostCtrProdClassNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
