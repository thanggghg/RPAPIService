using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InvoiceHeader
{
    public int InvHdrNoPk { get; set; }

    public int InvBlheaderNoFk { get; set; }

    public string InvNumber { get; set; }

    public decimal InvAmount { get; set; }

    public decimal? InvPayment { get; set; }

    public decimal? InvComission { get; set; }

    public int RecStatusNoFk { get; set; }

    public int InvStatusNoFk { get; set; }

    public DateTime InvDate { get; set; }

    public DateTime? InvShipDate { get; set; }

    public string InvNote { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? InvSonumber { get; set; }
}
