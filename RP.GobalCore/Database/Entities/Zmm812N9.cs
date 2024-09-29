using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812N9
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int ParentGroupId { get; set; }

    public string N901RefIdq { get; set; }

    public string N902RefId { get; set; }

    public DateTime? CreatedDt { get; set; }
}
