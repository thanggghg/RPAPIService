using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SoshipTo
{
    public int SoshipToNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Sostscac { get; set; }

    public string Sostname { get; set; }

    public string Sostattn { get; set; }

    public string Sostaddress1 { get; set; }

    public string Sostaddress2 { get; set; }

    public string Sostaddress3 { get; set; }

    public string Sostcity { get; set; }

    public string Soststate { get; set; }

    public string SostzipCode { get; set; }

    public string SostpostalCode { get; set; }

    public string Sostcountry { get; set; }

    public string Sostphone1 { get; set; }

    public string Sostphone2 { get; set; }

    public string SostphoneExt { get; set; }

    public string Sostfax1 { get; set; }

    public string Sostfax2 { get; set; }

    public string Sostemail { get; set; }

    public string Sostremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string SostediwhsId { get; set; }
}
