using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class EmailWhitelist
{
    public string EmailPk { get; set; }

    public int? CustomerNoFk { get; set; }

    public int? VendorNoFk { get; set; }

    public string Name { get; set; }

    public int Type { get; set; }

    public int? TicketNumber { get; set; }

    public int Status { get; set; }

    public string ApprovedBy { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public string Reason { get; set; }

    public string Technician { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
