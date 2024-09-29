using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterCompoundingInstr
{
    public int BrmasterCmpInstrPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrmcmpMasterHeaderFk { get; set; }

    public int BrmcmpProductTypeFk { get; set; }

    public string BrmcmpStepNo { get; set; }

    public string BrmcmpStepInstr { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
