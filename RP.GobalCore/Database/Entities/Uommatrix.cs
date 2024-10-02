using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Uommatrix
{
    public int UomprodClassFk { get; set; }

    public int UomprodTypeFk { get; set; }

    public int UomcodeFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Uomname { get; set; }

    public string Uomdesc { get; set; }

    public bool? RequireDensity { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
