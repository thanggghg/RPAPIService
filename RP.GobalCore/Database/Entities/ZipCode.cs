using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ZipCode
{
    public string ZipCodeNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ZipStateCode { get; set; }

    public string ZipCity { get; set; }

    public string ZipCounty { get; set; }

    public double ZipLongitude { get; set; }

    public double ZipLatitude { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
