using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecDetailLog
{
    public int FgspecDetailPk { get; set; }

    public int FgspecHeaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? OrderId { get; set; }

    public int? SectionId { get; set; }

    public string SectionTitle { get; set; }

    public string Rmcode { get; set; }

    public string Analysis { get; set; }

    public string Specification { get; set; }

    public string Method { get; set; }

    public byte IsActive { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string Comments { get; set; }
}
