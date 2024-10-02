using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Mfschedule
{
    public int MfschedNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Imcode { get; set; }

    public string Imversion { get; set; }

    public decimal Qty { get; set; }

    public string Notes { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Fonumber { get; set; }
}
