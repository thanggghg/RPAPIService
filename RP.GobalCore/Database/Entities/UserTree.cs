using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class UserTree
{
    public int UserTreeNoPkbk { get; set; }

    public string UserTreeUsersIdFk { get; set; }

    public bool UserTreePermission { get; set; }

    public int UserTreeAppsTreeNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string UserPermission { get; set; }

    public bool WebUserTreePermission { get; set; }
}
