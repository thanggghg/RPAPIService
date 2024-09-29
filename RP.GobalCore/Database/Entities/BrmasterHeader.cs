using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterHeader
{
    public int BrmasterHeaderNoPk { get; set; }

    public decimal? Brmhversion { get; set; }

    public int BrmhfgitemMasterNoFk { get; set; }

    public decimal BrmhfgitemMasterVer { get; set; }

    public int BrmhstatusNoFk { get; set; }

    public int BrmhcustomerNoFk { get; set; }

    public int? BrmhbatchUomFk { get; set; }

    public int BrmhproductTypeNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal? BrmhunitWt { get; set; }

    public decimal? BrmhservingSize { get; set; }

    public string Brmhsize { get; set; }

    public string Brmhshape { get; set; }

    public string Brmhcolor { get; set; }

    public string BrmhpillCavity { get; set; }

    public string BrmhpillCavitySize { get; set; }

    public string BrmhgelType { get; set; }

    public string BrmhgelColor { get; set; }

    public string Brmhhardness { get; set; }

    public string Brmhthickness { get; set; }

    public string Brmhdisintegrate { get; set; }

    public string Brmhcoating { get; set; }

    public string BrmhcapsuleCode { get; set; }

    public decimal? BrmhemptyCapsuleWt { get; set; }

    public string Brmhremarks { get; set; }

    public int? Brmhpack { get; set; }

    public double? BrmhalertPct { get; set; }

    public string BrmhalertTargetWt { get; set; }

    public double? BrmhctrlPct { get; set; }

    public string BrmhctrlTargetWt { get; set; }

    public string BrmhribbonThickness { get; set; }

    public string BrmhribbonRange { get; set; }

    public string BrmhmachineSpeed { get; set; }

    public string BrmhsampledBy { get; set; }

    public DateTime? BrmhsampledDate { get; set; }

    public string Brmqcsremarks { get; set; }

    public string Brmencremarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string BrmhhardnessTarget { get; set; }

    public string BrmhhardnessRange { get; set; }

    public string BrmhthicknessTarget { get; set; }

    public string BrmhthicknessRange { get; set; }

    public bool? Uspproduct { get; set; }

    public decimal? BrmhunitWtTarget { get; set; }

    public string BrmhcoatCode { get; set; }

    public string BrmhcoatWtGain { get; set; }

    public string BrmhformatVer { get; set; }

    public int? RnDcoatFmlHdrFk { get; set; }

    public int? RnDcoat2FmlHdrFk { get; set; }

    public int? RnDcoat3FmlHdrFk { get; set; }

    public virtual ICollection<BrmasterBlendInstr> BrmasterBlendInstrs { get; set; } = new List<BrmasterBlendInstr>();

    public virtual ICollection<BrmasterCoatFml> BrmasterCoatFmls { get; set; } = new List<BrmasterCoatFml>();
}
