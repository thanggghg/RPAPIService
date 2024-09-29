using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class UserDeptTemplate
{
    public int AppTreeFk { get; set; }

    public bool IsWrite { get; set; }

    public string Department { get; set; }

    public bool? IsSupervisor { get; set; }

    public string TitleId { get; set; }
}
