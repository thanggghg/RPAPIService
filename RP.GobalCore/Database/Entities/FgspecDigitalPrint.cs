using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecDigitalPrint
{
    public int FgspecHeaderNoFk { get; set; }

    public byte[] FgspecFile { get; set; }

    public string UserList { get; set; }

    public string UserModified { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
