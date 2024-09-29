using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecCpnUseRemove
{
    public string ImCode { get; set; }

    public string Po { get; set; }

    public string So { get; set; }

    public string Customer { get; set; }

    public string MfgLot { get; set; }

    public string PkgBatch { get; set; }

    public double? Output { get; set; }

    public DateTime? DateCompl { get; set; }

    public string RmCode { get; set; }

    public string WhseLot { get; set; }

    public double? TotalUsed { get; set; }
}
