using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProductionCode
{
    public int ProductionCodeNoPk { get; set; }

    public int ProductionCodeCategoryNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ProductionCodeName { get; set; }

    public string ProductionCodeDesc { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
