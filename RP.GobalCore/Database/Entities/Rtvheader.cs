using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Rtvheader
{
    public int RtvnoPk { get; set; }

    public string Ponumber { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RtvstatusNoFk { get; set; }

    public string Rtvscac { get; set; }

    public DateTime? RequestDt { get; set; }

    public string VendorSaleRep { get; set; }

    public string Instruction { get; set; }

    public string StstrName { get; set; }

    public string StstrAddress1 { get; set; }

    public string StstrAddress2 { get; set; }

    public string StstrCity { get; set; }

    public string StstrState { get; set; }

    public string StstrZip { get; set; }

    public string StstrPostal { get; set; }

    public string StstrCountry { get; set; }

    public string StstrAttn { get; set; }

    public string StstrPhone1 { get; set; }

    public string StstrPhoneExt { get; set; }

    public string StstrPhone2 { get; set; }

    public string StstrFax1 { get; set; }

    public string StstrFax2 { get; set; }

    public string StstrEmail { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
