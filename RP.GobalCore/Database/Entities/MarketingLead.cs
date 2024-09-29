using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class MarketingLead
{
    public string LeadCode { get; set; }

    public string LeadDesc { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string DeptGroup { get; set; }

    public string Notes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
