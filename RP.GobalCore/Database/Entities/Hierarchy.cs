using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Hierarchy
{
    public string TitleId { get; set; }

    public string Title { get; set; }

    public string ManagerId { get; set; }

    public string Department { get; set; }
}
