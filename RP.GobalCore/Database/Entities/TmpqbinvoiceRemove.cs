using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpqbinvoiceRemove
{
    public string ShipImcode { get; set; }

    public string Customer { get; set; }

    public string Year { get; set; }

    public decimal? ShipQty { get; set; }

    public decimal? Amount { get; set; }
}
