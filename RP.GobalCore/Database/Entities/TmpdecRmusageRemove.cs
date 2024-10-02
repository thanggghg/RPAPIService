using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecRmusageRemove
{
    public string ImCode { get; set; }

    public string Po { get; set; }

    public string Customer { get; set; }

    public string MfgLot { get; set; }

    public string PkgBatch { get; set; }

    public DateTime? DateCompl { get; set; }

    public string RmCode { get; set; }

    public string WhseLot { get; set; }

    public double? UsedQty { get; set; }

    public double? F10 { get; set; }

    public string F11 { get; set; }
}
