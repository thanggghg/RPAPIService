using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CodeType
{
    public int CodeTypeNoPk { get; set; }

    public int CodeCategoryFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool CtypeRm { get; set; }

    public bool CtypeFg { get; set; }

    public string CtypeName { get; set; }

    public string CtypeDescription { get; set; }

    public string CtypeCreatedBy { get; set; }

    public DateTime CtypeCreatedDt { get; set; }

    public string CtypeLastUpdBy { get; set; }

    public DateTime CtypeLastUpdDt { get; set; }
}
