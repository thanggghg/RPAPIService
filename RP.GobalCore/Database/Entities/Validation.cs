using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Validation
{
    public string ValidationCode { get; set; }

    public string Description { get; set; }

    public bool IsProofRequired { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual ICollection<ValidationOption> ValidationOptions { get; set; } = new List<ValidationOption>();
}
