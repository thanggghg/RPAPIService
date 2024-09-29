using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingUsageHeader
{
    public int PkgUsedHeaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int PkgStatusNoFk { get; set; }

    public int ItemMasterNoFk { get; set; }

    public int? CustomerNoFk { get; set; }

    public int? Sonum { get; set; }

    public string Ponum { get; set; }

    public int BatchSize { get; set; }

    public int? EstimatePackQty { get; set; }

    public int? TotalPackQty { get; set; }

    public int? TotalBulkQty { get; set; }

    public string Uom { get; set; }

    public DateTime? ExpireDt { get; set; }

    public DateTime? QcapproveDt { get; set; }

    public string Postby { get; set; }

    public DateTime? PostDt { get; set; }

    public string Notes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public byte? PkgPostStatusFk { get; set; }

    public decimal? ImorderQty { get; set; }

    public string WhsLoc { get; set; }

    public int? PkgSchedPriority { get; set; }

    public DateTime? PkgSchedReadyDt { get; set; }

    public string PkgSchedReadyBy { get; set; }

    public DateTime? PkgSchedRecvDt { get; set; }

    public string PkgSchedRecvBy { get; set; }

    public string PkgSchedNotes { get; set; }

    public string PkgSchedRoom { get; set; }

    public byte[] PkgBrfile { get; set; }

    public bool? HasIssues { get; set; }

    public int? Pversion { get; set; }

    public virtual ICollection<PackagingUsageBrdetail> PackagingUsageBrdetails { get; set; } = new List<PackagingUsageBrdetail>();

    public virtual ICollection<PackagingUsageRmdetail> PackagingUsageRmdetails { get; set; } = new List<PackagingUsageRmdetail>();
}
