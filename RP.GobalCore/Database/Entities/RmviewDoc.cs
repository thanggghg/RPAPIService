using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmviewDoc
{
    public int ItemDocPk { get; set; }

    public string ItemCode { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ItemDocDirectory { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Remark { get; set; }
}
