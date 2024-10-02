using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TitleLevelRequest
{
    public int TlrnoPk { get; set; }

    public string TitleId { get; set; }

    public int AppsTreeNoFk { get; set; }

    public decimal Variable { get; set; }

    public int RequestLevel { get; set; }
}
