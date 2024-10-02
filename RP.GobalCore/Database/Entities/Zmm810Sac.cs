using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm810Sac
{
    public int SacPk { get; set; }

    public string Partner { get; set; }

    public int? SacinvoiceId { get; set; }

    public int? SacinvoiceItmid { get; set; }

    public int? Sacid { get; set; }

    public string SacallowanceOrCharge { get; set; }

    public string Saccode { get; set; }

    public double? Sacamount { get; set; }

    public string SacpercentQ { get; set; }

    public double? Sacpercent { get; set; }

    public double? Sacrate { get; set; }

    public string SacunitCd { get; set; }

    public double? Sacquantity { get; set; }

    public string SacmethodOfHandling { get; set; }

    public string SacrefId { get; set; }

    public string SacoptionNumber { get; set; }

    public string Sacdescription { get; set; }

    public string SaclanguageCd { get; set; }

    public DateTime? CreatedDt { get; set; }
}
