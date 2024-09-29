using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SobillTo
{
    public int SobillToNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Sobtname { get; set; }

    public string Sobtattn { get; set; }

    public string Sobtaddress1 { get; set; }

    public string Sobtaddress2 { get; set; }

    public string Sobtaddress3 { get; set; }

    public string Sobtcity { get; set; }

    public string Sobtstate { get; set; }

    public string SobtzipCode { get; set; }

    public string SobtpostalCode { get; set; }

    public string Sobtcountry { get; set; }

    public string Sobtphone1 { get; set; }

    public string Sobtphone2 { get; set; }

    public string SobtphoneExt { get; set; }

    public string Sobtfax1 { get; set; }

    public string Sobtfax2 { get; set; }

    public string Sobtemail { get; set; }

    public string Sobtremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string SobtediwhsId { get; set; }
}
