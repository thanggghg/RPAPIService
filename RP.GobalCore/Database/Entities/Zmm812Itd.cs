using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812Itd
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int ParentGroupId { get; set; }

    public string Itd01TermsTypeCd { get; set; }

    public string Idt02TermsBasisDateCd { get; set; }

    public double? Itd03TermsDoscountPct { get; set; }

    public int? Itd05TermsDiscountDaysDue { get; set; }

    public int? Itd07TermsNetDays { get; set; }

    public DateTime? CreatedDt { get; set; }
}
