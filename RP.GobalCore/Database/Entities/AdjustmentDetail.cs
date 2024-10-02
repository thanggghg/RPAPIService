using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class AdjustmentDetail
{
    public int AdjdetailNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int AdjdstatusNoFk { get; set; }

    public int? AdjdjheaderNoFk { get; set; }

    public int AdjditemKeyNoFk { get; set; }

    public string AdjditemId { get; set; }

    public int AdjdproductClassNoFk { get; set; }

    public int AdjdtransTypeNoFk { get; set; }

    public double Adjdqty { get; set; }

    public string Adjdreason { get; set; }

    public string AdjdmanLot { get; set; }

    public string AdjdwhsLot { get; set; }

    public int? AdjvendorId { get; set; }

    public bool? IsCustSupply { get; set; }

    public string Caller { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? Adjdsonum { get; set; }

    public string Adjdimcode { get; set; }
}
