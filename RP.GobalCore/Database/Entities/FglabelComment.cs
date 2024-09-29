using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FglabelComment
{
    public int FglabelCommentNoPk { get; set; }

    public int FglabelNoPk { get; set; }

    public string Comment { get; set; }

    public bool IsSystem { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
