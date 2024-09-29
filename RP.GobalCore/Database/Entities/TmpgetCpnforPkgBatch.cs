using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpgetCpnforPkgBatch
{
    public int Id { get; set; }

    public int? BatchPriority { get; set; }

    public string BatchNo { get; set; }

    public int? Pversion { get; set; }

    public decimal BatchQty { get; set; }

    public string ItemCode { get; set; }

    public string ItemDesc { get; set; }

    public decimal? BatchItemRequiredQty { get; set; }

    public decimal? BatchItemAdjAllocQty { get; set; }

    public decimal? BatchItemUsedQty { get; set; }

    public decimal RemainOh { get; set; }

    public decimal RemainQc { get; set; }

    public decimal RemainPo { get; set; }

    public bool IsFg { get; set; }

    public DateTime SohdueDate { get; set; }

    public DateTime LastUpdDt { get; set; }
}
