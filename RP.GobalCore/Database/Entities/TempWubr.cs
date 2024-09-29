using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TempWubr
{
    public int? BrlotPriority { get; set; }

    public string Brlot { get; set; }

    public int LotQty { get; set; }

    public string Rmcode { get; set; }

    public DateTime? SohdueDate { get; set; }
}
