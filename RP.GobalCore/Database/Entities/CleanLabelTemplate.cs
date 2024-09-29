using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CleanLabelTemplate
{
    public int CleanLabelPk { get; set; }

    public string Cldesc { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Type { get; set; }
}
