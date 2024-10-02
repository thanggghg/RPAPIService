using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingUsageRmdetail
{
    public int PkgUsedRmdetailNoPk { get; set; }

    public int PkgUsedRmheaderNoFk { get; set; }

    public int EntryOrdered { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? PkgRawMaterialNoFk { get; set; }

    public string PkgRmcode { get; set; }

    public string PkgRmdesc { get; set; }

    public string RmwhsLotNumber { get; set; }

    public int? VendorNoFk { get; set; }

    public string VendorLot { get; set; }

    public int? PkgInvTransNoFk { get; set; }

    public decimal? QtyRequested { get; set; }

    public decimal? QtyActualUsed { get; set; }

    public decimal? QtyDestroyed { get; set; }

    public decimal? QtyTotalUsed { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? PostNum { get; set; }

    public bool? IsFg { get; set; }

    public decimal? UnitQty { get; set; }

    public decimal? RequiredQty { get; set; }

    public decimal? QtyRemain { get; set; }

    public bool? HasIssues { get; set; }

    public virtual PackagingUsageHeader PkgUsedRmheaderNoFkNavigation { get; set; }
}
