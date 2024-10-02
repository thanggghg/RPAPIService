using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDgelFormulaHeader
{
    public int GelFormulaHeaderNoPk { get; set; }

    public int? GelColorImFk { get; set; }

    public string GelColorImcode { get; set; }

    public string GelColorImdesc { get; set; }

    public int AppearanceColorFk { get; set; }

    public string GelMassCode { get; set; }

    public string GelMassDesc { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal Version { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string Remarks { get; set; }

    public string GelSource { get; set; }

    public virtual ICollection<RnDgelFormulaDetail> RnDgelFormulaDetails { get; set; } = new List<RnDgelFormulaDetail>();
}
