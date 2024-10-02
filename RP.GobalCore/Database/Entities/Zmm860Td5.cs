using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860Td5
{
    public int Td5Id { get; set; }

    public string Partner { get; set; }

    public string Td5Po { get; set; }

    public DateTime? Td5PoDate { get; set; }

    public string Td501RoutingSeqCd { get; set; }

    public string Td502IdentificationCdq { get; set; }

    public string Td503IdentificationCd { get; set; }

    public string Td504TransportationTypeCd { get; set; }

    public string Td505Routing { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
