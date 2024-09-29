using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterSgwupInstr
{
    public int BrmasterSgwupInstrPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrmsgwupMasterHeaderFk { get; set; }

    public int BrmsgwupProductTypeFk { get; set; }

    public string BrmsgwupStepNo { get; set; }

    public string BrmsgwupStepInstr { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
