using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgreturnHeader
{
    public int FgreturnHeaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string FgrhrtrnAuthzNum { get; set; }

    public int FgrhstatusNoFk { get; set; }

    public DateTime FgrhorgShipDate { get; set; }

    public DateTime? FgrhreturnDate { get; set; }

    public int FgrhcustNumFk { get; set; }

    public string Fgrhfreight { get; set; }

    public string FgrhfreightPayBy { get; set; }

    public string FgrhsfstrName { get; set; }

    public string FgrhsfstrAttn { get; set; }

    public string FgrhsfstrAddress1 { get; set; }

    public string FgrhsfstrAddress2 { get; set; }

    public string FgrhsfstrCity { get; set; }

    public string FgrhsfstrState { get; set; }

    public string FgrhsfstrZip { get; set; }

    public string FgrhsfstrPostal { get; set; }

    public string FgrhsfstrCountry { get; set; }

    public string FgrhstfstrPhone1 { get; set; }

    public string FgrhsfstrPhoneExt { get; set; }

    public string FgrhsfstrPhone2 { get; set; }

    public string FgrhsfstrFax1 { get; set; }

    public string FgrhsfstrFax2 { get; set; }

    public string FgrhsfstrEmail { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string Fgrhnotes { get; set; }

    public virtual ICollection<FgreturnDetail> FgreturnDetails { get; set; } = new List<FgreturnDetail>();
}
