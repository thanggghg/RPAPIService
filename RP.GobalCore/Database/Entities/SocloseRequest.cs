using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SocloseRequest
{
    public int RequestId { get; set; }

    public int Sonumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public int SocrstatusNoFk { get; set; }

    public int RequestType { get; set; }

    public string RequestReason { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
