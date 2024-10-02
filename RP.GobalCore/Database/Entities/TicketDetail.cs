using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TicketDetail
{
    public string TdnoPk { get; set; }

    public string TicketId { get; set; }

    public string Comment { get; set; }

    public bool IsSolution { get; set; }

    public bool IsSystem { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }
}
