using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ColorCode
{
    public int ColorCodeNoPk { get; set; }

    public string Ccname { get; set; }

    public string Ccdescription { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool Sofgel2Colors { get; set; }

    public byte[] Picture { get; set; }

    public virtual ICollection<FgitemMaster> FgitemMasters { get; set; } = new List<FgitemMaster>();
}
