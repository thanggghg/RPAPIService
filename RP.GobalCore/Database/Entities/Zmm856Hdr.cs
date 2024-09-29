using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm856Hdr
{
    public int HdrPk { get; set; }

    public int Processing { get; set; }

    public DateTime? Sent { get; set; }

    public string Partner { get; set; }

    public int? Bsn02ControlNumber { get; set; }

    public DateTime? Bsn03Date { get; set; }

    public double? Td107ShipmentWeight { get; set; }

    public string Td108WeightUom { get; set; }

    public string Td503Scac { get; set; }

    public string Td504Method { get; set; }

    public string Ref01Rfq { get; set; }

    public string Ref02Blnumber { get; set; }

    public string Ref02Pronumber { get; set; }

    public string Ref02TgtProNumber { get; set; }

    public DateTime? Dtm01Shipped { get; set; }

    public string N104BuyerCode { get; set; }

    public string Prf01Ponumber { get; set; }

    public string Pid04Descr { get; set; }

    public string Td101PkgCode { get; set; }

    public int? Td102TotalBoxes { get; set; }

    public string N102ShipFromName { get; set; }

    public string N401City { get; set; }

    public string N402State { get; set; }

    public string N403Zip { get; set; }

    public int? Ctt01NumberOfLineItems { get; set; }

    public DateTime? CreatedDt { get; set; }
}
