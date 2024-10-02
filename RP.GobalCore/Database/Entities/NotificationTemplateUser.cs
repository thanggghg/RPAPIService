using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class NotificationTemplateUser
{
    public int NotifTemplateUserNoPk { get; set; }

    public double NotifTemplateNoFk { get; set; }

    public string NotifTemplateUsersId { get; set; }

    public bool IsDepartment { get; set; }
}
