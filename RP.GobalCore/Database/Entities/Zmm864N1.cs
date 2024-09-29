using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm864N1
{
    public int N1Id { get; set; }

    public int? ParentId { get; set; }

    public string N101Idc { get; set; }

    public string N102Name { get; set; }

    public string N103Idcq { get; set; }

    public string N104Idc { get; set; }

    public DateTime? GentranTimeStamp { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? CreatedDt { get; set; }
}
