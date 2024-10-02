using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerQuote
{
    public int CustQuoteNoPk { get; set; }

    public int CustomerNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string SaleRep { get; set; }

    public string Formulas { get; set; }

    public byte[] AttachedForm { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
