using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmlotPickForBr
{
    public int RmlotPickForBrPk { get; set; }

    public string Brlot { get; set; }

    public string Imcode { get; set; }

    public string Rmcode { get; set; }

    public string WhsLot { get; set; }

    public string LabelClaim { get; set; }

    public decimal MgPerUnit { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
