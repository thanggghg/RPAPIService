using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingUsageBrdetail
{
    public int PkgUsedBrdetailNoPk { get; set; }

    public int PkgUsedBrheaderNoFk { get; set; }

    public int PostStatusNoFk { get; set; }

    public string Brlot { get; set; }

    public string BlisterLot { get; set; }

    public int BrheaderNoFk { get; set; }

    public decimal BulkUnitQty { get; set; }

    public decimal PackQty { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? PostNum { get; set; }

    public decimal? PostPacked { get; set; }

    public string MixLot { get; set; }

    public decimal? PostSample { get; set; }

    public virtual PackagingUsageHeader PkgUsedBrheaderNoFkNavigation { get; set; }
}
