using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Sopodetail
{
    public int Id { get; set; }

    public int? ItemMasterNoFk { get; set; }

    public int IdRoot { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ItemId { get; set; }

    public string ItemDesc { get; set; }

    public string Uom { get; set; }

    public double Qty { get; set; }

    public double? QtyShipped { get; set; }

    public int? ItemCount { get; set; }

    public double UnitPrice { get; set; }

    public double Total { get; set; }

    public string Notes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool ForComboPkg { get; set; }

    public double? NewQty { get; set; }

    public virtual Soheader IdRootNavigation { get; set; }
}
