using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PhyTransferBatchHeader
{
    public int BatchPk { get; set; }

    public string ItemType { get; set; }

    public string WhsLoc { get; set; }

    public bool IsReceive { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Remarks { get; set; }

    public virtual ICollection<PhyTransferBatchDetail> PhyTransferBatchDetails { get; set; } = new List<PhyTransferBatchDetail>();
}
