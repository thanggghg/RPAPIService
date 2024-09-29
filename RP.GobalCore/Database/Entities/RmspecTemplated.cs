using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmspecTemplated
{
    public int SortId { get; set; }

    public string Analysis { get; set; }

    public string Specification { get; set; }

    public string Method { get; set; }

    public int? SectionId { get; set; }

    public string SectionTitle { get; set; }

    public bool IsComponent { get; set; }
}
