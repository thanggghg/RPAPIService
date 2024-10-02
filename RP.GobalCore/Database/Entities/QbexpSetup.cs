using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QbexpSetup
{
    public int Qbeid { get; set; }

    public string QbelistFile { get; set; }

    public string QbeoutFile { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
