using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class WeighUpDetail
{
    public int WudetailNoPk { get; set; }

    public bool WudaddInItem { get; set; }

    public int RecStatusNoFk { get; set; }

    public int WudstatusNoFk { get; set; }

    public int? WudbatchNoFk { get; set; }

    public decimal Wudqty { get; set; }

    public int WudrawMateriallNoFk { get; set; }

    public string WuditemId { get; set; }

    public string WuditemDesc { get; set; }

    public string WudwhslotNumber { get; set; }

    public int WudbrheaderNoFk { get; set; }

    public int WudvendorNoFk { get; set; }

    public string WudmanLot { get; set; }

    public string WudvendorLot { get; set; }

    public DateTime? WudweighedUpDate { get; set; }

    public string WudweighedUpBy { get; set; }

    public DateTime? WudpostedDate { get; set; }

    public string WuppostedBy { get; set; }

    public int? WudinvTransNoFk { get; set; }

    public string WudorderEntrySeq { get; set; }

    public string Wudnotes { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? WupkgSoFk { get; set; }

    public int? WupkgImFk { get; set; }

    public string WuwhsLocation { get; set; }

    public int? WudloadNumber { get; set; }

    public decimal? WuddestroyQty { get; set; }
}
