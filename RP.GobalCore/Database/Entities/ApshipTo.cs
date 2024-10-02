using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ApshipTo
{
    public int ApshipToNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Apstname { get; set; }

    public string Apstattn { get; set; }

    public string Apstaddress1 { get; set; }

    public string Apstaddress2 { get; set; }

    public string Apstaddress3 { get; set; }

    public string Apstcity { get; set; }

    public string Apststate { get; set; }

    public string ApstzipCode { get; set; }

    public string ApstpostalCode { get; set; }

    public string Apstcountry { get; set; }

    public string Apstphone1 { get; set; }

    public string Apstphone2 { get; set; }

    public string ApstphoneExt { get; set; }

    public string Apstfax1 { get; set; }

    public string Apstfax2 { get; set; }

    public string Apstemail { get; set; }

    public string Apstremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
