using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailPackagingEstimateRemove
{
    public int CostDetaiPkgNoPk { get; set; }

    public int CdcostHeaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal CdcountPerPkgUnit { get; set; }

    public string CdpkgUnitDesc { get; set; }

    public decimal CdbulkCostPerPkgUnit { get; set; }

    public decimal CdcpnCostPerPkgUnit { get; set; }

    public decimal? CdextraCostPerPkgUnit { get; set; }

    public int CdestNumPkgUnit { get; set; }

    public int? CdpkgCodeTypeNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual CostHeaderEstimate CdcostHeaderNoFkNavigation { get; set; }
}
