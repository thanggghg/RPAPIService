using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InvoicePayment
{
    public int InvPaymentNoPk { get; set; }

    public string InvNumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal InvPayAmount { get; set; }

    public DateTime InvPayDate { get; set; }

    public string InvPayCheck { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
