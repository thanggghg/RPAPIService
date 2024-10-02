using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ValidationOption
{
    public int VoptionNoPk { get; set; }

    public string ValidationCode { get; set; }

    public string OptionDescription { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual Validation ValidationCodeNavigation { get; set; }

    public virtual ICollection<ValidationResponse> ValidationResponses { get; set; } = new List<ValidationResponse>();
}
