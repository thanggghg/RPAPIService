using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class UserTreeRequest
{
    public int UserTreeReqNoPk { get; set; }

    public string UserTreeReqUsersIdFk { get; set; }

    public int UserTreeReqAppsTreeNoFk { get; set; }

    public string UserPermissionType { get; set; }

    public int? RecStatusNoFk { get; set; }
}
