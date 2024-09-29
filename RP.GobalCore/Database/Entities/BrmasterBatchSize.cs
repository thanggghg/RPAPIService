using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterBatchSize
{
    public int BrmasterBatchSizePk { get; set; }

    public int BrmmasterHdrFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal BrmbatchSize { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public decimal? Brmimver { get; set; }
}
