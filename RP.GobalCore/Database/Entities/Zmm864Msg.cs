using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm864Msg
{
    public int MsgId { get; set; }

    public int? ParentId { get; set; }

    public string Msg01Text { get; set; }

    public string Msg02Cd { get; set; }

    public int? Msg03Num { get; set; }

    public DateTime? GentranTimeStamp { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? CreatedDt { get; set; }
}
