using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Form
{
    public string Id { get; set; }

    public string Description { get; set; }

    public string Tag { get; set; }

    public bool GetClosedData { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? MenuId { get; set; }
}
