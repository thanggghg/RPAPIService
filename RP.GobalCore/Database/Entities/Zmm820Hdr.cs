using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820Hdr
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string Brp01Transactioncode { get; set; }

    public double? Brp02Total { get; set; }

    public string Brp03Cd { get; set; }

    public string Brp04Payment { get; set; }

    public DateTime? Brp16Date { get; set; }

    public string Brp17BusinessCode { get; set; }

    public string Trn01TraceType { get; set; }

    public string Trn02TraceId { get; set; }

    public string Cur02Currency { get; set; }

    public DateTime? CreatedDt { get; set; }
}
