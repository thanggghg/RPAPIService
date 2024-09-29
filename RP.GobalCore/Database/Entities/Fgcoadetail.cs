using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fgcoadetail
{
    public int FgcoadetailPk { get; set; }

    public int FgcoaheaderFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RmcodeFk { get; set; }

    public int? SectionId { get; set; }

    public int? OrderId { get; set; }

    public string SectionTitle { get; set; }

    public string Analysis { get; set; }

    public string Specification { get; set; }

    public string Method { get; set; }

    public string Result { get; set; }

    public string Reference { get; set; }

    public byte IsActive { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
