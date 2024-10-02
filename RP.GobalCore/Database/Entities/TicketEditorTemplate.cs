using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TicketEditorTemplate
{
    public int Id { get; set; }

    public string Description { get; set; }

    public string Template { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
