using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860Itd
{
    public int ItdId { get; set; }

    public string Partner { get; set; }

    public string ItdPo { get; set; }

    public DateTime? ItdPoDate { get; set; }

    public string Itd01TermsTypeCd { get; set; }

    public string Itd02TermsBasisDateCd { get; set; }

    public double? Itd03TermsDiscountPct { get; set; }

    public DateTime? Itd04DiscountDiscountDueDate { get; set; }

    public int? Itd05TermsDiscountDaysDue { get; set; }

    public DateTime? Itd06TermsNetDueDate { get; set; }

    public int? Itd07TermsNetDays { get; set; }

    public double? Itd08TermsDiscountAmount { get; set; }

    public DateTime? Itd09TermsDeferedDueDate { get; set; }

    public double? Itd10DeferedAmt { get; set; }

    public double? Itd11PctInvPayable { get; set; }

    public string Itd12Description { get; set; }

    public int? Itd13DayOfMonth { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
