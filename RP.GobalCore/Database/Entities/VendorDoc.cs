using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class VendorDoc
{
    public int ItemDocPk { get; set; }

    public string FormRequestNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ItemDocName { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public DateTime? ExpiredDate { get; set; }
}
