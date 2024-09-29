using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ImlabelDoc
{
    public int ImlabelDocPk { get; set; }

    public string FormRequestNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ImlabelDocName { get; set; }

    public string ImlabelDocType { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
