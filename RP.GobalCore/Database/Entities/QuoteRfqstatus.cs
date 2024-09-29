using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteRfqstatus
{
    public byte RfqstatusId { get; set; }

    public string Rfqstatus { get; set; }

    public string Type { get; set; }
}
