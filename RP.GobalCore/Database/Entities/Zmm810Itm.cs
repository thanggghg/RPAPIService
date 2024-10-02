using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm810Itm
{
    public int Itmid { get; set; }

    public string Partner { get; set; }

    public int? ItminvoiceId { get; set; }

    public double? Itmquantity { get; set; }

    public string Itmunit { get; set; }

    public double? ItmunitPrice { get; set; }

    public string ItmcountryOfOrigin { get; set; }

    public string ItmEanUcc13 { get; set; }

    public string ItmwalMartItemNumber { get; set; }

    public string Itmupccode { get; set; }

    public string Itmgtin { get; set; }

    public string Itmucc12 { get; set; }

    public string ItmlotNumber { get; set; }

    public string ItmmutuallyDefined { get; set; }

    public string Itmdescription { get; set; }

    public int? Itmpack { get; set; }

    public int? ItminnerPack { get; set; }

    public int? ItmsacId { get; set; }

    public DateTime? CreatedDt { get; set; }
}
