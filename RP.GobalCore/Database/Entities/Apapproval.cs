using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Apapproval
{
    public int ApapprovalNoPk { get; set; }

    public string Apaponumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public double ApatotalPrice { get; set; }

    public string AparequestReason { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? ApaisApproved { get; set; }

    public string ApaapprovedBy { get; set; }

    public DateTime? ApaapprovedDt { get; set; }

    public string ApaapprovedReason { get; set; }

    public string ApaapprovedTitleId { get; set; }

    public int? ApasessionId { get; set; }

    public int? ApasessionStatus { get; set; }

    public bool? ApaisReadyToSign { get; set; }
}
