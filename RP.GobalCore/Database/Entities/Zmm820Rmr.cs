using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820Rmr
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int EntNo { get; set; }

    public string TraceId { get; set; }

    public int RecId { get; set; }

    public string Rmr01Idq { get; set; }

    public string Rmr02Id { get; set; }

    public string Rmr03ActionCd { get; set; }

    public double? Rmr04NetAmount { get; set; }

    public double? Rmr05Amount { get; set; }

    public DateTime? CreatedDt { get; set; }
}
