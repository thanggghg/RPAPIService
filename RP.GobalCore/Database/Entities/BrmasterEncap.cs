using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterEncap
{
    public int BrmasterEncPk { get; set; }

    public int BrmencMasterHeaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrmencParamId { get; set; }

    public double? BrmencTarget { get; set; }

    public double? BrmencRangeMin { get; set; }

    public double? BrmencRangeMax { get; set; }

    public double? BrmencTarget2 { get; set; }

    public double? BrmencRange2Min { get; set; }

    public double? BrmencRange2Max { get; set; }

    public double? BrmencTarget3 { get; set; }

    public double? BrmencRange3Min { get; set; }

    public double? BrmencRange3Max { get; set; }

    public int? BrmencAlertRngType { get; set; }

    public double? BrmencAlertMin { get; set; }

    public double? BrmencAlertMax { get; set; }

    public int? BrmencControlRngType { get; set; }

    public double? BrmencControlMin { get; set; }

    public double? BrmencControlMax { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
