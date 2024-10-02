using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SopodetailSubItemLog
{
    public int SopodetailSubItemPk { get; set; }

    public int SopodetailId { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ParentImcode { get; set; }

    public string ChildImcode { get; set; }

    public float ChildImqty { get; set; }

    public float SochildImqty { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? IsFg { get; set; }
}
