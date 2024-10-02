using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvDetail
{
    public int RcvDetailNoPk { get; set; }

    public int? RcvDbatchNoFk { get; set; }

    public int RcvDrcvHeaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RcvDstatusNoFk { get; set; }

    public decimal RcvDqtyPerPiece { get; set; }

    public decimal RcvDqaqtyPerPiece { get; set; }

    public decimal RcvDqtyReceived { get; set; }

    public decimal RcvDqtyQcaccepted { get; set; }

    public decimal RcvDqtyQcrejected { get; set; }

    public int RcvDpieces { get; set; }

    public int RcvDpcsQcaccepted { get; set; }

    public int RcvDpcsQcrejected { get; set; }

    public bool? RcvDcondRelease { get; set; }

    public DateTime? RcvDcondReleaseSet { get; set; }

    public DateTime? RcvDcondReleaseUnset { get; set; }

    public string RcvDwhsLotNumber { get; set; }

    public string RcvDvendorPo { get; set; }

    public string RcvDvendorLot { get; set; }

    public string RcvDqaverifiedVendorLot { get; set; }

    public DateTime? RcvDexpiredDate { get; set; }

    public DateTime? RcvDqaexpiredDate { get; set; }

    public DateTime? RcvDreceivedDate { get; set; }

    public string RcvDreceivedBy { get; set; }

    public DateTime? RcvDverifiedDate { get; set; }

    public string RcvDverifiedBy { get; set; }

    public string RcvDnotes { get; set; }

    public string RcvDqanotes { get; set; }

    public string Remarks { get; set; }

    public int? RcvDreturnedPcs { get; set; }

    public decimal? RcvDreturnedQty { get; set; }

    public string RcvDreturnedNotes { get; set; }

    public DateTime? RcvDreturnedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpddt { get; set; }

    public decimal? RcvDrtrnQtyPerPiece { get; set; }

    public string RcvDreturnedBy { get; set; }

    public bool? RcvDpostReady { get; set; }

    public virtual RcvHeader RcvDrcvHeaderNoFkNavigation { get; set; }
}
