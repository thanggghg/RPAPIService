using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpgetRmforBrlot
{
    public int Id { get; set; }

    public int? BrlotPriority { get; set; }

    public string Brlot { get; set; }

    public decimal LotQty { get; set; }

    public string Rmcode { get; set; }

    public bool ShellRm { get; set; }

    public decimal? LotRmrequireQty { get; set; }

    public decimal? LotRmwuqty { get; set; }

    public decimal? RemainOh { get; set; }

    public decimal? RemainQc { get; set; }

    public decimal? RemainPo { get; set; }

    public bool HasExpired { get; set; }

    public string Rmdescription { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? AvailQc { get; set; }

    public decimal? AvailPo { get; set; }

    public string WhsLots { get; set; }

    public int? ShellItemMasterNo { get; set; }

    public int? NextId { get; set; }
}
