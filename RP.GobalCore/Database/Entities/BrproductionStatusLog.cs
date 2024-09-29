using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrproductionStatusLog
{
    public int BrplnoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrhplbrheaderNoFk { get; set; }

    public int BrhpltaskCodeNoFk { get; set; }

    public string BrhplmanLot { get; set; }

    public string Brhplnotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
