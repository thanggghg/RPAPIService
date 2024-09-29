using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Adjrequest
{
    public int Id { get; set; }

    public string ReqGroupId { get; set; }

    public string ReqCode { get; set; }

    public int? ReqStatus { get; set; }

    public string ReqType { get; set; }

    public string ApproveType { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public string LastUpdatedBy { get; set; }

    public string RequestBy { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string ApprovedBy { get; set; }

    public string ItemId { get; set; }

    public string ItemCode { get; set; }

    public string ItemType { get; set; }

    public string WarehousesLoc { get; set; }

    public string Lot { get; set; }

    public string ToRack { get; set; }

    public decimal? AdjustQty { get; set; }

    public long? TransId { get; set; }

    public string AdjTrans { get; set; }

    public int? StatusItem { get; set; }

    public int? ReqAdjustType { get; set; }
}
