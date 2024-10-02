using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class AdjcenterLogRequest
{
    public long Id { get; set; }

    public string ReqGroupId { get; set; }

    public string ItemType { get; set; }

    public string ReqData { get; set; }

    public string ReqDataSend { get; set; }
}
