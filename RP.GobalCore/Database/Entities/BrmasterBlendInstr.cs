using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterBlendInstr
{
    public int BrmasterBlendInstrPk { get; set; }

    public int BrmbmasterHeaderFk { get; set; }

    public int BrmbproductTypeFk { get; set; }

    public string BrmbstepNo { get; set; }

    public string BrmbstepInstr { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public virtual BrmasterHeader BrmbmasterHeaderFkNavigation { get; set; }
}
