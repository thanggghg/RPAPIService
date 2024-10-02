using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Bomheader
{
    public int BmheaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BmhstatusNoFk { get; set; }

    public DateTime? BmhdeliveryDate { get; set; }

    public int BmhcustomerNoFk { get; set; }

    public int BmhsoheaderNoFk { get; set; }

    public int BmhsodetailNoFk { get; set; }

    public int? BmhaptransNoFk { get; set; }

    public int? BmhaptransNoFksave { get; set; }

    public bool BmhcustomerSuppplied { get; set; }

    public int BmhrawMaterialNoFk { get; set; }

    public string BmhrmitemNumber { get; set; }

    public int? BmhvendorNoFk { get; set; }

    public int BmhrminvTransNoFk { get; set; }

    public double Bmhbomqty { get; set; }

    public double? BmhpurchasedQty { get; set; }

    public double BmhallocatedQty { get; set; }

    public double? BmhweighedUpQty { get; set; }

    public double? BmhcurrAllocated { get; set; }

    public double? BmhcurrOh { get; set; }

    public double? BmhcurrInQc { get; set; }

    public double? BmhunitPrice { get; set; }

    public double? BmhextPrice { get; set; }

    public string Bmhnotes { get; set; }

    public bool BmhweighedUp { get; set; }

    public string Remarks { get; set; }

    public string BmhdeleteAction { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? BmhcurrOrder { get; set; }

    public string BmhpendingNote { get; set; }

    public int BomprodClassFk { get; set; }

    public int? BmhsopodetailFk { get; set; }

    public string BmhparentIm { get; set; }

    public virtual ICollection<BomdetailAllocAddIn> BomdetailAllocAddIns { get; set; } = new List<BomdetailAllocAddIn>();
}
