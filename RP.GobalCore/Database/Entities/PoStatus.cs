using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PoStatus
{
    public string AptrmitemNumber { get; set; }

    public string Rmdescription { get; set; }

    public string Aptapponumber { get; set; }

    public int? RmCost { get; set; }

    public DateTime AptdeliveryDate { get; set; }

    public DateTime? AptconfirmDt { get; set; }

    public int Postatus1 { get; set; }

    public DateTime Aphpodate { get; set; }

    public string Dep { get; set; }

    public int TrnStatus { get; set; }

    public double ExpectedQty { get; set; }

    public decimal Received { get; set; }

    public decimal? Accepted { get; set; }

    public decimal? Rejected { get; set; }

    public DateTime? Qcdate { get; set; }

    public decimal? Returned { get; set; }

    public DateTime? ReturnedDate { get; set; }

    public bool RcvHisFullReceived { get; set; }

    public string ItemClass { get; set; }

    public int RcvHaptransNoFk { get; set; }

    public int RcvHeaderNoPk { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public string WhsLot { get; set; }

    public string VendorName { get; set; }

    public double Poqty { get; set; }

    public string ItemNote { get; set; }

    public decimal WupQty { get; set; }
}
