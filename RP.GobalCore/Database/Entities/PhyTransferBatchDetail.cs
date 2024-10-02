using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PhyTransferBatchDetail
{
    public int BatchDetailPk { get; set; }

    public int BatchHeaderFk { get; set; }

    public string Item { get; set; }

    public string Lot { get; set; }

    public int NumBox { get; set; }

    public decimal QtyPerBox { get; set; }

    public string PalletId { get; set; }

    public virtual PhyTransferBatchHeader BatchHeaderFkNavigation { get; set; }
}
