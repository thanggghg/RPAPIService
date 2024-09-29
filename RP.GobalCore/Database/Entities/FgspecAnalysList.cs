using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecAnalysList
{
    public int AnalysId { get; set; }

    public string UsersIdFk { get; set; }

    public string AnalysName { get; set; }
}
