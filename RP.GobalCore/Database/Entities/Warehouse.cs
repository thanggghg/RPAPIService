using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Warehouse
{
    public int WarehouseNoPk { get; set; }

    public string WhsName { get; set; }

    public int RecStatusNoFk { get; set; }

    public string WhsAttention { get; set; }

    public string WhsAddressLine1 { get; set; }

    public string WhsAddressLine2 { get; set; }

    public string WhsCity { get; set; }

    public string WhsState { get; set; }

    public string WhsZipCode { get; set; }

    public string WhsPostalCode { get; set; }

    public string WhsCountry { get; set; }

    public string WhsContactEmail { get; set; }

    public string WhsPhone1 { get; set; }

    public string WhsPhone2 { get; set; }

    public string WhsFax1 { get; set; }

    public string WhsFax2 { get; set; }

    public string WhsNotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
