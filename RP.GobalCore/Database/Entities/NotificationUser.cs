using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class NotificationUser
{
    public int NotifUsersNoPk { get; set; }

    public int NotificationId { get; set; }

    public string NotifUsersId { get; set; }

    public bool NotifStatus { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
