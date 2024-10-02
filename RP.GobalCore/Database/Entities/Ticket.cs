using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Ticket
{
    public string Id { get; set; }

    public int Status { get; set; }

    public string Category { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int? MenuId { get; set; }

    public int Importance { get; set; }

    public string Tag { get; set; }

    public string UserList { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public bool? IsSendEmail { get; set; }

    public DateTime? DueDate { get; set; }
}
