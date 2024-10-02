using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class NotificationTemplate
{
    public double NotifTemplateNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string NotifTemplateType { get; set; }

    public string NotifTemplateMessage { get; set; }

    public string NotifTemplateValue { get; set; }

    public int? MenuId { get; set; }

    public string Note { get; set; }

    public string Url { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
