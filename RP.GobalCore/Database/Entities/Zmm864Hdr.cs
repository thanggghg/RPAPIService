using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm864Hdr
{
    public int CnfId { get; set; }

    public string Description { get; set; }

    public string TransactionPurpose { get; set; }

    public string TransactionType { get; set; }

    public DateTime? Processed { get; set; }

    public DateTime? GentranTimeStamp { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? CreatedDt { get; set; }
}
