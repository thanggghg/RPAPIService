using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SotimeLineEvent
{
    public int SotimeLineNoPk { get; set; }

    public string EventName { get; set; }

    public string EventDescription { get; set; }

    public int DisplayOrder { get; set; }

    public int? DaysRange { get; set; }

    public bool? IsSelected { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
