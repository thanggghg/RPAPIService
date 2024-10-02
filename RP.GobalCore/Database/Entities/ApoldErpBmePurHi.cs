using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ApoldErpBmePurHi
{
    public string Ponum { get; set; }

    public DateTime? ItemDta { get; set; }

    public DateTime? Podate { get; set; }

    public string VendorName { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? PobatchNum { get; set; }

    public int? PostatusFk { get; set; }

    public bool? ActiveVendor { get; set; }

    public decimal? PoordQty { get; set; }

    public decimal? PorecvQty { get; set; }

    public string Ponote { get; set; }

    public bool? RmrecvStatus { get; set; }

    public string Rmcode { get; set; }

    public string Remarks { get; set; }
}
