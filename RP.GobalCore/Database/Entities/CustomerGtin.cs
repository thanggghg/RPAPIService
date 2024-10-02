using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerGtin
{
    public int Id { get; set; }

    public string StoreNo { get; set; }

    public string Gln { get; set; }

    public string Duns { get; set; }

    public string StoreName { get; set; }

    public string StoreType { get; set; }

    public bool Dc { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string Address3 { get; set; }

    public string Address4 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string Country { get; set; }

    public string Phone { get; set; }

    public string Manager { get; set; }
}
