using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RminvTransRemove
{
    public int RmtransNoPk { get; set; }

    public int RmtcustomerNoFk { get; set; }

    public string Rmtponumber { get; set; }

    public int RmtrawMaterialNoFk { get; set; }

    public string RmtrmitemNumber { get; set; }

    public int Rmtrmpack { get; set; }

    public int RmtproductClassNoFk { get; set; }

    public int RmtproductTypeNoFk { get; set; }

    public int? RmtvendorNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RmtransRef { get; set; }

    public int RmttransTypeNoFk { get; set; }

    public int RmttransSourceNoFk { get; set; }

    public bool RmtadjustmentTrans { get; set; }

    public DateTime RmttransDate { get; set; }

    public DateTime? RmtrmexpirationDate { get; set; }

    public string RmtvendorLot { get; set; }

    public string RmtmanLot { get; set; }

    public string RmtwhsLot { get; set; }

    public double RmttransQty { get; set; }

    public decimal RmttransUnitCost { get; set; }

    public decimal RmttransExtCost { get; set; }

    public string Rmtnotes { get; set; }

    public string RmtxferedFromDeptNoFk { get; set; }

    public string RmtxferedToDeptNoFk { get; set; }

    public string RmtweeklyBped { get; set; }

    public string RmtmonthlyBped { get; set; }

    public string Remarks { get; set; }

    public string RmremarksDevUtil { get; set; }

    public string Caller { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
