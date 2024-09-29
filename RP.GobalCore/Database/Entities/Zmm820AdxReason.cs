using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820AdxReason
{
    public int Id { get; set; }

    public string ReasonCode { get; set; }

    public string Reason { get; set; }

    public DateTime? CreatedDt { get; set; }
}
