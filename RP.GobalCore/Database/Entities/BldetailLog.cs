using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BldetailLog
{
    public int BldetailLogPk { get; set; }

    public int? BldetailNoPk { get; set; }

    public int? BldheaderNoFk { get; set; }

    public int? RecStatusNoFk { get; set; }

    public int? BldstatusNoFk { get; set; }

    public int? BldfginvLotNoFk { get; set; }

    public string BldmanLotNumber { get; set; }

    public string BldwhsLotNumber { get; set; }

    public int? BlditemMasterNoFk { get; set; }

    public string BlditemId { get; set; }

    public int? Bldpack { get; set; }

    public string BlditemDesc { get; set; }

    public int? Bldcount { get; set; }

    public int? BldunitQty { get; set; }

    public int? BldqtyPerCase { get; set; }

    public string Bldsku { get; set; }

    public string Bldupc { get; set; }

    public string Bldsscc18 { get; set; }

    public int? BldcaseQty { get; set; }

    public string BldcustProdCode { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public int? BldcaseCustOrder { get; set; }
}
