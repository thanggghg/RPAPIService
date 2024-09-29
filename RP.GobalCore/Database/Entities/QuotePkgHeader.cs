using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuotePkgHeader
{
    public int QpheaderPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? RnDfmlNoFk { get; set; }

    public int? ItemMasterNoFk { get; set; }

    public int? PackCount { get; set; }

    public int? QuoteBulkHdrFk { get; set; }

    public int? CustomerFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public DateTime? QhapprovedDt { get; set; }

    public string QhapprovedBy { get; set; }

    public virtual ICollection<QuotePkgCostDetailEstimate> QuotePkgCostDetailEstimates { get; set; } = new List<QuotePkgCostDetailEstimate>();

    public virtual ICollection<QuotePkgCpnDetailEstimate> QuotePkgCpnDetailEstimates { get; set; } = new List<QuotePkgCpnDetailEstimate>();

    public virtual ICollection<QuotePkgLaborDetailEstimate> QuotePkgLaborDetailEstimates { get; set; } = new List<QuotePkgLaborDetailEstimate>();

    public virtual ICollection<QuotePkgOvrHdDetailEstimate> QuotePkgOvrHdDetailEstimates { get; set; } = new List<QuotePkgOvrHdDetailEstimate>();
}
