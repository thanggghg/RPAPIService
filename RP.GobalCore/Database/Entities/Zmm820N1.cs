using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820N1
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string TraceId { get; set; }

    public int RecId { get; set; }

    public string N101EntityId { get; set; }

    public string N102Name { get; set; }

    public string N103Idq { get; set; }

    public string N104Id { get; set; }

    public DateTime? CreatedDt { get; set; }
}
