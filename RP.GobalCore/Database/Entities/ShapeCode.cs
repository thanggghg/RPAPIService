using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ShapeCode
{
    public int ShapeCodeNoPk { get; set; }

    public string ScproductTypes { get; set; }

    public string Scname { get; set; }

    public string Scdescription { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public byte[] Picture { get; set; }

    public virtual ICollection<FgitemMaster> FgitemMasters { get; set; } = new List<FgitemMaster>();
}
