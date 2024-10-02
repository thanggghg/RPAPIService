using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Qbmapping
{
    public int Id { get; set; }

    public int? RecStatusNoFk { get; set; }

    public string Rpitem { get; set; }

    public string Qbitem { get; set; }
}
