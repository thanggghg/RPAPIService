using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Qbitem
{
    public int Qbiid { get; set; }

    public string QbiitemName { get; set; }

    public string QbiitemType { get; set; }

    public string QbirefNum { get; set; }

    public int? Qbiaccount { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
