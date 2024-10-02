using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostDetailPkgTemplateRemove
{
    public int CostDetailPkgEstPk { get; set; }

    public string PkgDesc { get; set; }

    public decimal PkgCost { get; set; }

    public int PkgCodeTypeNoFk { get; set; }
}
