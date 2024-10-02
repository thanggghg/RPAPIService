using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDgelFormulaDetailLog
{
    public int GelFormulaDetailLogPk { get; set; }

    public int GelFormulaDetailNoPk { get; set; }

    public int GelFormulaHeaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmitemFk { get; set; }

    public string Rmcode { get; set; }

    public string Rmdescription { get; set; }

    public decimal Rmpercent { get; set; }

    public string OrderId { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
