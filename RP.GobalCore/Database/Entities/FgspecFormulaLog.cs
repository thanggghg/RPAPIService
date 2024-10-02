using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecFormulaLog
{
    public int FgspecFormulaPk { get; set; }

    public int FgspecHeaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int SortOrder { get; set; }

    public string Label { get; set; }

    public decimal? UnitWt { get; set; }

    public decimal? PctOver { get; set; }

    public bool ActiveIngredient { get; set; }

    public string Rmcode { get; set; }

    public string Rmdesc { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
