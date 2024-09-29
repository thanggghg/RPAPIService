using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812Cdd
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int GroupId { get; set; }

    public int ParentGroupId { get; set; }

    public string Cdd01ReasonCd { get; set; }

    public string Cdd02CrDebFlagCd { get; set; }

    public string Cdd03AssignedId { get; set; }

    public double? Cdd04Amount { get; set; }

    public double? Cdd07CrDebQuantity { get; set; }

    public string Cdd08Uom { get; set; }

    public string Cdd10PriceIdc { get; set; }

    public double? Cdd11UnitPrice { get; set; }

    public string Cdd12PriceIdc { get; set; }

    public double? Cdd13UnitPrice { get; set; }

    public string Cdd14Msg { get; set; }

    public string Lin01AssignedId { get; set; }

    public string Lin02ProductIdq { get; set; }

    public string Lin03ProductId { get; set; }

    public string Lin04ProductIdq { get; set; }

    public string Lin05ProductId { get; set; }

    public string Lin06ProductIdq { get; set; }

    public string Lin07ProductId { get; set; }

    public string Lin08ProductIdq { get; set; }

    public string Lin09ProductId { get; set; }

    public string Lin10ProductIdq { get; set; }

    public string Lin11ProductId { get; set; }

    public DateTime? CreatedDt { get; set; }
}
