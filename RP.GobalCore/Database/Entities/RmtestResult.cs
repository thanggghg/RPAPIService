using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmtestResult
{
    public int RmtestResultPk { get; set; }

    public string Rmcode { get; set; }

    public string WhsLot { get; set; }

    public string TestCode { get; set; }

    public decimal TestResult { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Note { get; set; }

    public virtual RawMaterial RmcodeNavigation { get; set; }
}
