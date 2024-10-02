using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuotePkgCpnDetailEstimate
{
    public int QpcomponentDetailPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int QpcpnHdrFk { get; set; }

    public int RmitemFk { get; set; }

    public decimal? Rmqty { get; set; }

    public decimal? RmunitCost { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? IsFg { get; set; }

    public int? QuoteBulkFk { get; set; }

    public int? ParentKey { get; set; }

    public virtual QuotePkgHeader QpcpnHdrFkNavigation { get; set; }
}
