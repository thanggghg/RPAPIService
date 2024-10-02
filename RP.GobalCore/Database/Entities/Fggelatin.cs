using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fggelatin
{
    public int GelatinNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int GelatinGelItemItemMasterNoFk { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string Notes { get; set; }

    public int? RnDgelFormulaHeaderFk { get; set; }

    public int? GelatinItemMasterNoFk { get; set; }

    public string GelatinEntryOrdered { get; set; }
}
