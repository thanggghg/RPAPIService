using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDcoatingFormulaHeaderLog
{
    public int CoatingFormulaHeaderLogPk { get; set; }

    public int CoatingFormulaHeaderNoPk { get; set; }

    public string CoatingCode { get; set; }

    public string CoatingDesc { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal Version { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string LastUpdatedBy { get; set; }

    public string Remarks { get; set; }
}
