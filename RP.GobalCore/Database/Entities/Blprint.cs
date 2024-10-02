using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Blprint
{
    public int BlprintNoPk { get; set; }

    public int BlpheaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BlprecortType { get; set; }

    public string BlpcustPo { get; set; }

    public int? BlpcustPkgCnt { get; set; }

    public double? BlpcustWeight { get; set; }

    public bool? BlpcustPallet { get; set; }

    public string BlpcustInfo { get; set; }

    public int? BlpcarrierHuqty { get; set; }

    public string BlpcarrierHutype { get; set; }

    public int? BlpcarrierPkQty { get; set; }

    public string BlpcarrierPkType { get; set; }

    public double? BlpcarrierWeight { get; set; }

    public bool? BlpcarrierHazMat { get; set; }

    public string BlpcarrierDescr { get; set; }

    public string BlpcarrierNmfc { get; set; }

    public string BlpcarrierClass { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
