using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecPkgBatchRemove
{
    public string PkgBatch { get; set; }

    public decimal? PackQty { get; set; }

    public bool Posted { get; set; }

    public bool? Manual { get; set; }
}
