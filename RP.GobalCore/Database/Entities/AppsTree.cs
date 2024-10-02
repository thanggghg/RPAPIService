using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class AppsTree
{
    public int AppsTreeNoPk { get; set; }

    public int? AppsTreeSortOrder { get; set; }

    public string AppsTreeName { get; set; }

    public int AppsTreeParentNode { get; set; }

    public int RecStatusNoFk { get; set; }

    public bool? Visible { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string AppsDirectory { get; set; }

    public bool WebView { get; set; }

    public string WebViewType { get; set; }

    public int? TreeLevel { get; set; }

    public bool IsMobile { get; set; }
}
