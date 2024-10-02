using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterInstr
{
    public int BrmasterInstrPk { get; set; }

    public string Brminstruction { get; set; }

    public int BrmproductTypeFk { get; set; }

    public string BrminstrCategory { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }
}
