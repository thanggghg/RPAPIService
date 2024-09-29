using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class UompillSize
{
    public int UompillSizeCodePk { get; set; }

    public string Uompsname { get; set; }

    public string Uompsdescription { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
