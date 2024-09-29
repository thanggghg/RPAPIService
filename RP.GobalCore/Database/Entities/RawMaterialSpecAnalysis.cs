using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialSpecAnalysis
{
    public int RmspecAnalysisNoPk { get; set; }

    public int RmsaspecNoFk { get; set; }

    public int RmsaspecId { get; set; }

    public int RecStatusNoFk { get; set; }

    public int Rmsaversion { get; set; }

    public string Rmsaanalysis { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdby { get; set; }

    public DateTime LastUpdDt { get; set; }
}
