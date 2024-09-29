using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Manufacturer
{
    public int MfrPk { get; set; }

    public string MfrName { get; set; }

    public int RecStatusNoFk { get; set; }

    public string MfrAddr1 { get; set; }

    public string MfrAddr2 { get; set; }

    public string MfrCity { get; set; }

    public string MfrState { get; set; }

    public string MfrZipCode { get; set; }

    public string MfrCountry { get; set; }

    public string MfrPhone1 { get; set; }

    public string MfrPhone2 { get; set; }

    public string MfrPhoneExt1 { get; set; }

    public string MfrPhoneExt2 { get; set; }

    public string MfrFax1 { get; set; }

    public string MfrFax2 { get; set; }

    public string MfrUrl { get; set; }

    public string MfrContactName { get; set; }

    public string MfrContactEmail { get; set; }

    public string MfrContactPhone { get; set; }

    public string MfrCorpEmail { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? IsForeign { get; set; }
}
