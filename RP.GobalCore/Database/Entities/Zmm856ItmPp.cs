using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm856ItmPp
{
    public int CdPk { get; set; }

    public int? ParentFk { get; set; }

    public string Partner { get; set; }

    public int Processed { get; set; }

    public string Man02 { get; set; }

    public int? Hlid { get; set; }

    public int? Hlparent { get; set; }

    public int? ItemHlid { get; set; }

    public int? ItemHlparent { get; set; }

    public string Upc { get; set; }

    public string Scc14 { get; set; }

    public string CustCode { get; set; }

    public string ItemDescr { get; set; }

    public int? Sn102NumberOfUnits { get; set; }

    public int? Sonumber { get; set; }

    public int? Soqty { get; set; }

    public int? SoshippedToDate { get; set; }

    public string Sn102Uom { get; set; }

    public int? Po401Pack { get; set; }

    public DateTime? CreatedDt { get; set; }
}
