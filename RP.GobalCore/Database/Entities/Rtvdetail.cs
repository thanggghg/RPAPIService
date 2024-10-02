using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Rtvdetail
{
    public int RtvdetailNoPk { get; set; }

    public int RtvnoFk { get; set; }

    public int RcvDetailNoFk { get; set; }

    public int RtvnumBox { get; set; }

    public decimal RtvqtyPerBox { get; set; }

    public decimal RtvreturnQty { get; set; }

    public string Reason { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
