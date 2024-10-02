using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PickTicketBinLocation
{
    public string WhsLot { get; set; }

    public int PtdhdrNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string BinLocation { get; set; }

    public int NumBox { get; set; }

    public decimal QtyPerBox { get; set; }

    public decimal BinQty { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
