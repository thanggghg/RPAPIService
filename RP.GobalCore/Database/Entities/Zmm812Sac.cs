using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812Sac
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int GroupId { get; set; }

    public int ParentGroupId { get; set; }

    public string Sac01AllowanceOrCharge { get; set; }

    public string Sac02ServiceCd { get; set; }

    public double? Sac05Amount { get; set; }

    public string Sac06PctQ { get; set; }

    public double? Sac07Pct { get; set; }

    public double? Sac08Rate { get; set; }

    public string Sac09Uom { get; set; }

    public double? Sac10Quantity { get; set; }

    public DateTime? CreatedDt { get; set; }
}
