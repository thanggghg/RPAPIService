using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CodeCategory
{
    public int CodeCategoryPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CcatName { get; set; }

    public string CcatDescription { get; set; }

    public DateTime CcatStatusDt { get; set; }

    public string CcatCreatedBy { get; set; }

    public DateTime CcatCreatedDt { get; set; }

    public string CcatLastUpdBy { get; set; }

    public DateTime CcatLastUpdDt { get; set; }

    public byte[] MsreplSynctranTs { get; set; }
}
