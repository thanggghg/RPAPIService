using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Notification
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string Message { get; set; }

    public int? MenuId { get; set; }

    public string Value { get; set; }

    public string Url { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public int? ResponseId { get; set; }
}
