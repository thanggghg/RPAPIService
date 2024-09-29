using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820Ref
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string TraceId { get; set; }

    public int EntNo { get; set; }

    public int RecId { get; set; }

    public string Rmrref01Idq { get; set; }

    public string Rmrref02Id { get; set; }

    public DateTime? CreatedDt { get; set; }
}
