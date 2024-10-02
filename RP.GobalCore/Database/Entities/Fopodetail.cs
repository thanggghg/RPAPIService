using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fopodetail
{
    public int FopodetailNoPk { get; set; }

    public string FoheaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ItemId { get; set; }

    public decimal Qty { get; set; }

    public bool? Bomcreated { get; set; }

    public DateTime? BomcreatedDt { get; set; }

    public string ImcustomerNoFk { get; set; }

    public string Notes { get; set; }

    public string Remarks { get; set; }

    public string ItemMasterVer { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
