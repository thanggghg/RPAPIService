using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgpackInstruction
{
    public int FgpkgInstrNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int OrderId { get; set; }

    public string SectionId { get; set; }

    public string SectionTitle { get; set; }

    public string Instruction { get; set; }

    public string InstructionValue { get; set; }

    public int ImcodeFk { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
