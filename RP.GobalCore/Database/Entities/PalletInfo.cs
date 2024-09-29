using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PalletInfo
{
    public int PalletInfoPk { get; set; }

    public string PalletId { get; set; }

    public string CustPonum { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Note { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
