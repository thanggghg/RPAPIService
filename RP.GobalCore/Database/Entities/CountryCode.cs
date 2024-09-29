using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CountryCode
{
    public string CountryCodePk { get; set; }

    public string CountryName { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
