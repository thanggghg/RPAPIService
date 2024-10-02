using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PickTicketDetail
{
    public int PtdnoPk { get; set; }

    public int PtdhdrNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string WhsLot { get; set; }

    public bool LockWhsLot { get; set; }

    public string LockWhsLotBy { get; set; }

    public DateTime? LockWhsLotDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? UseQty { get; set; }

    public string Notes { get; set; }
}
