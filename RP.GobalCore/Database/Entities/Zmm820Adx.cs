using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820Adx
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int EntNo { get; set; }

    public string TraceId { get; set; }

    public int RecId { get; set; }

    public int? ParentId { get; set; }

    public double? Adx01Amount { get; set; }

    public string Adx02ReasonCd { get; set; }

    public string Adx03RefIdq { get; set; }

    public string Adx04RefId { get; set; }

    public DateTime? CreatedDt { get; set; }
}
