using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Wslog
{
    public int WslogId { get; set; }

    public string WslogMethod { get; set; }

    public string WslogMessage { get; set; }

    public string WslogUsersIdFk { get; set; }

    public string WslogWindowsId { get; set; }

    public string WslogIpaddress { get; set; }

    public DateTime WslogTime { get; set; }

    public string WslogMenu { get; set; }
}
