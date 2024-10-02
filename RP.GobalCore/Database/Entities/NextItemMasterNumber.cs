using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class NextItemMasterNumber
{
    public int NextNumber { get; set; }

    public int ProdType { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? PilotIm { get; set; }
}
