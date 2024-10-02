using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProdSchedule
{
    public int ProdSchedNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string MachineName { get; set; }

    public string BrorPkgLot { get; set; }

    public int LoadorPostNum { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Notes { get; set; }

    public bool? SchedDone { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public decimal? EncapQty { get; set; }

    public string DieSerial { get; set; }

    public string SchedType { get; set; }
}
