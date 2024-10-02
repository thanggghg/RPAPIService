using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ReceiveRm
{
    public int RcvHeaderNoPk { get; set; }

    public int RcvHitemKeyNoFk { get; set; }

    public string RcvHitemNumber { get; set; }

    public string RcvhitemDesc { get; set; }

    public decimal RcvHqtyReceived { get; set; }

    public decimal? RcvHreturnedQty { get; set; }

    public int RcvHvendorNoFk { get; set; }

    public string RcvHapponumber { get; set; }

    public DateTime? RcvHdateExpected { get; set; }

    public decimal RcvHqtyExpected { get; set; }

    public int? RcvDstatusNoFk { get; set; }

    public int? RcvDpieces { get; set; }

    public decimal? RcvDqtyPerPiece { get; set; }

    public decimal? RcvDqtyReceived { get; set; }

    public DateTime? RcvDreceivedDate { get; set; }

    public string RcvDwhsLotNumber { get; set; }

    public string RcvDvendorLot { get; set; }

    public string RcvDvendorPo { get; set; }

    public string RcvDnotes { get; set; }

    public string VendorName { get; set; }

    public decimal RmqtyAllocated { get; set; }

    public DateTime? RcvDqaexpiredDate { get; set; }

    public DateTime? RcvDverifiedDate { get; set; }

    public decimal? RcvDqtyQcaccepted { get; set; }

    public decimal? RcvDqtyQcrejected { get; set; }

    public string RcvStatus { get; set; }

    public int? UnitCost { get; set; }

    public int? Aphterms { get; set; }

    public string AphorderedBy { get; set; }

    public string Aphordered4Dept { get; set; }

    public int? ApttransUnitPrice { get; set; }

    public double? ApttransQty { get; set; }

    public DateTime? Podate { get; set; }

    public DateTime? AptconfirmDt { get; set; }

    public string ItemClass { get; set; }
}
