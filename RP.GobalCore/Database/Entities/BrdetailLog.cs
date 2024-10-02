using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrdetailLog
{
    public int BrdlogPk { get; set; }

    public string BrdlotNumber { get; set; }

    public int BrdtankNumber { get; set; }

    public string BrdtankWuby { get; set; }

    public DateTime? BrdtankWudt { get; set; }

    public string BrdtankWustartBy { get; set; }

    public string BrdtankWuendBy { get; set; }

    public string BrdtankBlendBy { get; set; }

    public DateTime? BrdtankBlendDt { get; set; }

    public string BrdtankBlendStartBy { get; set; }

    public DateTime? BrdtankBlendStartDt { get; set; }

    public string BrdtankBlendEndBy { get; set; }

    public DateTime? BrdtankBlendEndDt { get; set; }

    public string BrdtankEncapBy { get; set; }

    public DateTime? BrdtankEncapDt { get; set; }

    public string BrdtankCoatBy { get; set; }

    public DateTime? BrdtankCoatDt { get; set; }

    public string BrdtankInspectBy { get; set; }

    public DateTime? BrdtankInspectDt { get; set; }
}
