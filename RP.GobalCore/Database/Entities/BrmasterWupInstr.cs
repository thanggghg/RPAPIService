using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterWupInstr
{
    public int BrmasterWupInstrPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrmwupMasterHeaderFk { get; set; }

    public int BrmwupProductTypeFk { get; set; }

    public string BrmwupStepNo { get; set; }

    public string BrmwupStepInstr { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
