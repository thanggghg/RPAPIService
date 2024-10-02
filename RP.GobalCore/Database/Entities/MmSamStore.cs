using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class MmSamStore
{
    public string StoreNo { get; set; }

    public string Gln { get; set; }

    public string Duns { get; set; }

    public string Address1 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string Phone { get; set; }

    public string Manager { get; set; }

    public string ReceivingPhone { get; set; }
}
