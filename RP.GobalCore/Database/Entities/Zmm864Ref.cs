using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm864Ref
{
    public int RefId { get; set; }

    public int? ParentId { get; set; }

    public string Ref01Idc { get; set; }

    public string Ref02Id { get; set; }

    public DateTime? GentranTimeStamp { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? CreatedDt { get; set; }
}
