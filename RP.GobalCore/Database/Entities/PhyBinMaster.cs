using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PhyBinMaster
{
    public int PhyBinMasterPk { get; set; }

    public string WhsLoc { get; set; }

    public string BinLoc { get; set; }

    public string BinDesc { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
