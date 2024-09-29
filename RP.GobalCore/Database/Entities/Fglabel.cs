using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fglabel
{
    public int FglabelNoPk { get; set; }

    public string Imcode { get; set; }

    public string Imdesc { get; set; }

    public string LabelVersion { get; set; }

    public string BulkVersion { get; set; }

    public int? FglabelStatus { get; set; }

    public string CustomerName { get; set; }

    public string CustomerProductName { get; set; }

    public string CustomerItem { get; set; }

    public string CustomerUpcbarCode { get; set; }

    public string CustomerPart { get; set; }

    public string CustomerVer { get; set; }

    public string ComponentCode { get; set; }

    public float? UnitCount { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string ReviewedBy { get; set; }
}
