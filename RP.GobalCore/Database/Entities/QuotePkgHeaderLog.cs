using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuotePkgHeaderLog
{
    public int LogId { get; set; }

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
}
