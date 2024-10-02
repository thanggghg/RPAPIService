using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmspecDetailLog
{
    public int RmspecDetailNoPk { get; set; }

    public int RmsdheaderFk { get; set; }

    public int RmsdorderId { get; set; }

    public int? SectionId { get; set; }

    public string SectionTitle { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Rmsdanalysis { get; set; }

    public string Rmsdmethod { get; set; }

    public string Rmsdspec { get; set; }

    public bool RmsdhasSpecLab { get; set; }

    public string Rmsdnotes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdby { get; set; }

    public DateTime LastUpdDt { get; set; }
}
