using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgitemMasterByLot
{
    public int ImbyLotPk { get; set; }

    public string Imcode { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Brlot { get; set; }

    public int? Sonum { get; set; }

    public float? ImlotOnHandQty { get; set; }

    public float? ImlotOnOrderQty { get; set; }

    public float? ImlotAllocQty { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string OldBrlot { get; set; }
}
