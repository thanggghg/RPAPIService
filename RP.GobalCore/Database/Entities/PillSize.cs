using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PillSize
{
    public int PillSizeNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int PsproductTypeNoFk { get; set; }

    public string Pssize { get; set; }

    public string PssortedKey { get; set; }

    public bool? PsdefaultedSize { get; set; }

    public int? PscavityPerRound { get; set; }

    public int? PsroundPerDice { get; set; }

    public string ReMarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual ICollection<FgitemMaster> FgitemMasters { get; set; } = new List<FgitemMaster>();
}
