using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm856Itm
{
    public int CdPk { get; set; }

    public string ItemSequence { get; set; }

    public int? ParentFk { get; set; }

    public string Partner { get; set; }

    public int? CdRecType { get; set; }

    public string Hlc { get; set; }

    public string CdType { get; set; }

    public string CdData { get; set; }

    public string ItemDescr { get; set; }

    public int? Sn102NumberOfUnits { get; set; }

    public int? Sonumber { get; set; }

    public int? Soqty { get; set; }

    public int? SoshippedToDate { get; set; }

    public string Sn102Uom { get; set; }

    public int? Po401Pack { get; set; }

    public DateTime? CreatedDt { get; set; }
}
