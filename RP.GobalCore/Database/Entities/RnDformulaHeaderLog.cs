using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RnDformulaHeaderLog
{
    public int RnDlogHeaderNoPk { get; set; }

    public int RnDformulaHeaderNoPk { get; set; }

    public int? RnDfhrootId { get; set; }

    public string RnDfholdFmlCode { get; set; }

    public int? RnDfholdFmlId { get; set; }

    public int? RnDfhparentNoFk { get; set; }

    public int RnDfhstatusNoFk { get; set; }

    public int? RnDfhfgitemMasterNoFk { get; set; }

    public int RnDfhcustomerNoFk { get; set; }

    public int RnDfhbatchUomFk { get; set; }

    public int RndFhproductTypeNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal RnDfhversion { get; set; }

    public string RnDfhformulaCode { get; set; }

    public string RnDfhformulaDesc { get; set; }

    public string RnDfhnotes { get; set; }

    public decimal RnDfhbatchSize { get; set; }

    public decimal RnDfhtotalUnitWt { get; set; }

    public decimal RnDfhtotalWt { get; set; }

    public decimal? RnDfhservingSize { get; set; }

    public string RnDfhsize { get; set; }

    public string RnDfhshape { get; set; }

    public string RnDfhcolor { get; set; }

    public string RnDfhpillCavity { get; set; }

    public string RnDfhpillCavitySize { get; set; }

    public string RnDfhgelType { get; set; }

    public string RnDfhgelColor { get; set; }

    public string RnDfhgeDesc { get; set; }

    public string RnDfhhardness { get; set; }

    public string RnDfhthickness { get; set; }

    public string RnDfhdisintegrate { get; set; }

    public string RnDfhcoating { get; set; }

    public string RnDfhcapsuleCode { get; set; }

    public decimal? RnDfhemptyCapsuleWt { get; set; }

    public string RnDfhprodRun { get; set; }

    public string RnDfhinst { get; set; }

    public string RnDfhremarks { get; set; }

    public DateTime? RnDfhconvertImdate { get; set; }

    public int? RnDfhpack { get; set; }

    public decimal? RnDfhpctYield { get; set; }

    public decimal? RnDfhalertLimit { get; set; }

    public string RnDfhalertRange { get; set; }

    public decimal? RnDfhcontrolLimit { get; set; }

    public string RnDfhcontrolRange { get; set; }

    public decimal? RnDfhribbonThickness { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string Comment { get; set; }

    public int? RnDgelFormulaHeaderFk { get; set; }

    public int? RnDgelFormulaHeader2Fk { get; set; }

    public int? RnDgelFormulaHeader3Fk { get; set; }

    public string RnDfhcapuleDesc { get; set; }

    public int? RnDcoatingFormulaHeaderFk { get; set; }

    public int? RnDcoatingFormulaHeader2Fk { get; set; }

    public int? RnDcoatingFormulaHeader3Fk { get; set; }

    public decimal? RnDgelUnitWt { get; set; }

    public decimal? RnDgel2UnitWt { get; set; }

    public decimal? RnDgel3UnitWt { get; set; }

    public decimal? RnDcoatingUnitWt { get; set; }

    public decimal? RnDcoating2UnitWt { get; set; }

    public decimal? RnDcoating3UnitWt { get; set; }

    public string RnDfhgelColor2 { get; set; }

    public string RnDfhgelColor3 { get; set; }

    public decimal? RnDfhimver { get; set; }

    public int? RnDfhdailyDose { get; set; }

    public string RnDmachineType { get; set; }

    public decimal? RnDgelThickness { get; set; }

    public decimal? RnDrpm { get; set; }

    public decimal? RnDpctGelLost { get; set; }

    public string RnDfhdryWt { get; set; }

    public string RnDfhdepositWt { get; set; }
}
