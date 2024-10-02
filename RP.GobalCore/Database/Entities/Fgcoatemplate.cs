using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fgcoatemplate
{
    public int SortOrder { get; set; }

    public string Analysis { get; set; }

    public bool? ExcludeFromSpec { get; set; }

    public string Specification { get; set; }

    public string Method { get; set; }

    public int? SectionId { get; set; }

    public string SectionTitle { get; set; }
}
