using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ApbillTo
{
    public int ApbillToNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Apbtname { get; set; }

    public string Apbtattn { get; set; }

    public string Apbtaddress1 { get; set; }

    public string Apbtaddress2 { get; set; }

    public string Apbtaddress3 { get; set; }

    public string Apbtcity { get; set; }

    public string Apbtstate { get; set; }

    public string ApbtzipCode { get; set; }

    public string ApbtpostalCode { get; set; }

    public string Apbtcountry { get; set; }

    public string Apbtphone1 { get; set; }

    public string Apbtphone2 { get; set; }

    public string ApbtphoneExt { get; set; }

    public string Apbtfax1 { get; set; }

    public string Apbtfax2 { get; set; }

    public string Apbtemail { get; set; }

    public string Apbtremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
