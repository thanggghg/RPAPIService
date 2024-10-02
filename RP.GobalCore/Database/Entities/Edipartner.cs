using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Edipartner
{
    public int PartnerPk { get; set; }

    public int RecStatusNoFk { get; set; }
    
    public string PartnerId { get; set; }

    public string PartnerName { get; set; }

    public bool UseSscc { get; set; }

    public int PalletLblCnt { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
