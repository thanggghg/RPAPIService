using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SobulkStatusOpen
{
    public int Sonum { get; set; }

    public string Imcode { get; set; }

    public string Brlot { get; set; }

    public decimal Brqty { get; set; }

    public int LoadNum { get; set; }

    public DateTime? Bomdt { get; set; }

    public DateTime? InWuschedDt { get; set; }

    public DateTime? WustartDt { get; set; }

    public DateTime? WuendDt { get; set; }

    public DateTime? BlendStartDt { get; set; }

    public DateTime? BlendEndDt { get; set; }

    public DateTime? EncapStartDt { get; set; }

    public DateTime? EncapEndDt { get; set; }

    public DateTime? CoatStartDt { get; set; }

    public DateTime? CoatEndDt { get; set; }

    public DateTime? InspectStartDt { get; set; }

    public DateTime? InspectEndDt { get; set; }

    public DateTime? ReleaseStartDt { get; set; }

    public DateTime? ReleaseEndDt { get; set; }

    public DateTime? BrcompleteDt { get; set; }

    public DateOnly? BrdueDt { get; set; }

    public DateTime? ShipDt { get; set; }
}
