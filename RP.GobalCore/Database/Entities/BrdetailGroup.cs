using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrdetailGroup
{
    public int BrdgroupPk { get; set; }

    public string Brdroom { get; set; }

    public string Notes { get; set; }

    public string Department { get; set; }
}
