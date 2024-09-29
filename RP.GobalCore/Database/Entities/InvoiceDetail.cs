using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class InvoiceDetail
{
    public int InvDetailNoPk { get; set; }

    public string InvNumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ItemName { get; set; }

    public decimal Qty { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? UnitCost { get; set; }

    public bool IsBl { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
