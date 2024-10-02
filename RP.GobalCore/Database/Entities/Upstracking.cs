using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Upstracking
{
    public int UpstrackingPk { get; set; }

    public string ProLeadNum { get; set; }

    public string ProNum { get; set; }

    public string Sonum { get; set; }

    public string CustPonum { get; set; }

    public string Blhnumber { get; set; }

    public string Upsservice { get; set; }

    public string VoidStatus { get; set; }

    public int RecStatusNoFk { get; set; }

    public DateTime CreatedDt { get; set; }
}
