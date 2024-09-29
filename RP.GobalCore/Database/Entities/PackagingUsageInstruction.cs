using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PackagingUsageInstruction
{
    public int PkgInstrNoPk { get; set; }

    public int PkgHdrNoFk { get; set; }

    public int? RecStatusNoFk { get; set; }

    public string SectionId { get; set; }

    public string SectionTitle { get; set; }

    public int? OrderId { get; set; }

    public string Instruction { get; set; }

    public string InstructionValue { get; set; }

    public string Remarks { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
