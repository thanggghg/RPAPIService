using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class MmWmStore
{
    public string StoreNo { get; set; }

    public string Gln { get; set; }

    public string Duns { get; set; }

    public string StoreName { get; set; }

    public string StoreType { get; set; }

    public string Address1 { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string MailingAddress { get; set; }

    public string MailingCity { get; set; }

    public string MailingState { get; set; }

    public string MailingZip { get; set; }

    public string Phone { get; set; }

    public string Size { get; set; }

    public string OpenDate { get; set; }

    public string RegionalDc { get; set; }

    public string DryGroceryDc { get; set; }

    public string PerishableDc { get; set; }

    public string SpecialtyDc { get; set; }
}
