using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterCoatInstr
{
    public int BrmasterCoatInstrPk { get; set; }

    public int BrmcmasterHeaderFk { get; set; }

    public int BrmcproductTypeFk { get; set; }

    public string BrmcstepNo { get; set; }

    public string BrmcstepInstr { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
