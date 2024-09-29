using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgreturnDetail
{
    public int FgreturnDetailNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int FgrdreturnHeaderNoFk { get; set; }

    public bool FgrdisWhrecv { get; set; }

    public string FgrdlotNum { get; set; }

    public string FgrditemCode { get; set; }

    public string FgrditemDesc { get; set; }

    public string FgrdcustPonum { get; set; }

    public int? FgrdqtyProduced { get; set; }

    public int Fgrdpack { get; set; }

    public int? FgrdqtyRtrnPerBox { get; set; }

    public int? FgrdqtyRtrnBox { get; set; }

    public int? FgrdqtyRtrnTotal { get; set; }

    public string FgrdrtrnReasonCode { get; set; }

    public string FgrdrtrnComment { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual FgreturnHeader FgrdreturnHeaderNoFkNavigation { get; set; }
}
