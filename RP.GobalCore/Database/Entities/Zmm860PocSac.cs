using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860PocSac
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string SacPo { get; set; }

    public DateTime? SacPoDate { get; set; }

    public string SacItemLineNumber { get; set; }

    public string Sac01SacIndicator { get; set; }

    public string Sac02SacCd { get; set; }

    public string Sac03AgencyQcd { get; set; }

    public string Sac04AgencyPromotionCd { get; set; }

    public double? Sac05Amount { get; set; }

    public string Sac06PercentQ { get; set; }

    public double? Sac07Percent { get; set; }

    public double? Sac08Rate { get; set; }

    public string Sac09Unit { get; set; }

    public double? Sac10Qty { get; set; }

    public double? Sac11Qty { get; set; }

    public string Sac12SacMethodOfHandlingCd { get; set; }

    public string Sac13ReferenceId { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
