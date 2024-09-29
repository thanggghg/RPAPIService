using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Foheader
{
    public int FoheaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int FohstatusNoFk { get; set; }

    public bool? Fohbrcreated { get; set; }

    public DateTime? FohbrcreatedDt { get; set; }

    public bool? Fohbomcreated { get; set; }

    public DateTime? FohbomcreatedDt { get; set; }

    public string FohcustomerNoFk { get; set; }

    public int? FohbillToNoFk { get; set; }

    public int? FohshipToNoFk { get; set; }

    public int? FohquoteHeaderNoFk { get; set; }

    public DateTime? FohdueDate { get; set; }

    public int? FohtermNoFk { get; set; }

    public string Fohrep { get; set; }

    public string FohsalesRep { get; set; }

    public string Fohnotes { get; set; }

    public DateTime? FohfoclosedDt { get; set; }

    public string FohfoclosedBy { get; set; }

    public string Fohremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public DateTime? FohfovoidedDt { get; set; }

    public string FohfovoidedBy { get; set; }

    public bool? FohpkgBomcreated { get; set; }

    public DateTime? FohpkgBomcreatedDt { get; set; }

    public string FohsalesRep2 { get; set; }

    public DateTime? FoconfirmDt { get; set; }

    public string FoconfirmBy { get; set; }

    public string FohcustNotes { get; set; }

    public DateTime? FopkgConfirmDt { get; set; }

    public string FopkgConfirmBy { get; set; }
}
