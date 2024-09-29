using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProductType
{
    public int ProductTypePk { get; set; }

    public string Ptname { get; set; }

    public bool IsDisplay { get; set; }

    public string Ptdescription { get; set; }

    public int ProductClassFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
