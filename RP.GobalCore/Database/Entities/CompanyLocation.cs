using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CompanyLocation
{
    public int RpaddrNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RpcorpName { get; set; }

    public string Rploc { get; set; }

    public string Rpattn { get; set; }

    public string Rpaddress1 { get; set; }

    public string Rpaddress2 { get; set; }

    public string Rpcity { get; set; }

    public string Rpstate { get; set; }

    public string RpzipCode { get; set; }

    public string RppostalCode { get; set; }

    public string Rpcountry { get; set; }

    public string Rpphone1 { get; set; }

    public string Rpphone2 { get; set; }

    public string Rpphone1Ext { get; set; }

    public string Rpfax1 { get; set; }

    public string Rpfax2 { get; set; }

    public string Rpemail { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Prefix { get; set; }

    public string Iprange { get; set; }
}
