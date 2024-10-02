using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgspecHeaderLog
{
    public int FgspecHeaderPk { get; set; }

    public int FgspecIdFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Imcode { get; set; }

    public string Imdesc { get; set; }

    public string Imsize { get; set; }

    public string Imcolor { get; set; }

    public DateTime? SpecIssueDate { get; set; }

    public string Specversion { get; set; }

    public string Imversion { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string TotalCapsuleWeight { get; set; }

    public string FillWeight { get; set; }

    public string WeightVariation { get; set; }

    public string DisintegrationRate { get; set; }

    public string Remarks { get; set; }

    public string CustomerCode { get; set; }

    public string AdditionalReqs { get; set; }

    public string ServingSize { get; set; }

    public string ExpiredIn { get; set; }

    public string FormulaCode { get; set; }

    public decimal? FormulaVer { get; set; }

    public string ApprovedBy { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public bool? AllergenCheck { get; set; }

    public bool? ExportOnly { get; set; }

    public string ShipToCountry { get; set; }

    public bool? UbxbeenReviewed { get; set; }

    public bool? UbxhasLabel { get; set; }

    public int? FgspecStatus { get; set; }

    public bool? UbxneedReview { get; set; }
}
