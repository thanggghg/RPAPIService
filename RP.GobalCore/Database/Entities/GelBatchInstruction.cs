using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GelBatchInstruction
{
    public int GbinoPk { get; set; }

    public int GbhdrNoFk { get; set; }

    public int? RecStatusNoFk { get; set; }

    public int? OrderId { get; set; }

    public string Instruction { get; set; }

    public string Remarks { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public virtual GelBatchInstruction GbhdrNoFkNavigation { get; set; }

    public virtual ICollection<GelBatchInstruction> InverseGbhdrNoFkNavigation { get; set; } = new List<GelBatchInstruction>();
}
