using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InvoiceTerm
{
    public int InvTermsNoPk { get; set; }

    public int ItinvoiceTerms { get; set; }

    public string Itdescription { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool PreOrderDeposit { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
