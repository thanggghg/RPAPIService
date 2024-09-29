using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDcoatingFormulaDetailLog
{
    public int CoatingFormulaDetailLogPk { get; set; }

    public int CoatingFormulaDetailNoPk { get; set; }

    public int CoatingFormulaHeaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Rmcode { get; set; }

    public string Rmdescription { get; set; }

    public decimal Rmpercent { get; set; }

    public string OrderId { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string LastUpdatedBy { get; set; }
}
