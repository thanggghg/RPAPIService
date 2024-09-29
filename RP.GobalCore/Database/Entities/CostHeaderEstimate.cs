using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CostHeaderEstimate
{
    public int CostHeaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int ChquoteHeaderNoFk { get; set; }

    public int? ChsoheaderNoFk { get; set; }

    public string ChitemNumber { get; set; }

    public int ChitemMasterNoFk { get; set; }

    public double ChgelatinRpm { get; set; }

    public double ChtotalCostPerThousand { get; set; }

    public double ChtotalCostPlusMarginPerThousand { get; set; }

    public bool ChtotalCostPlusPackaging { get; set; }

    public bool ChtotalCostPlusBottling { get; set; }

    public bool ChtotalCostPlusBlisterCard { get; set; }

    public bool ChtotalCostPlusHandCartoning { get; set; }

    public bool ChtotalCostPlusCoating { get; set; }

    public bool ChtotalCostPlusCapsuling { get; set; }

    public bool ChtotalCostPlusGelatin { get; set; }

    public int ChchosenMarginLevel { get; set; }

    public double ChtotalCostMargin1Percent { get; set; }

    public double ChtotalCostPlusMargin1 { get; set; }

    public double ChtotalCostMargin2Percent { get; set; }

    public double ChtotalCostPlusMargin2 { get; set; }

    public double ChtotalCostMargin3Percent { get; set; }

    public double ChtotalCostPlusMargin3 { get; set; }

    public double ChbulkLevelRmcost { get; set; }

    public double ChbulkLevelYieldPercent { get; set; }

    public double ChbulkLevelYieldShrinkageCost { get; set; }

    public double ChbulkLevelLaborCost { get; set; }

    public double ChbulkLevelOhcost { get; set; }

    public double ChbulkLevelTotalCost { get; set; }

    public double ChpkgLevelPkgCompCost { get; set; }

    public double ChpkgLevelLaborCost { get; set; }

    public double ChpkgLevelOhcost { get; set; }

    public double ChpkgLevelTotalCost { get; set; }

    public bool ChpkgLevelTotalCostAdd2TotalCost { get; set; }

    public double ChbottlingLevelPkgCompCost { get; set; }

    public double ChbottlingLevelShrinkagePercent { get; set; }

    public double ChbottlingLevelShrinkageCost { get; set; }

    public double ChbottlingLevelLaborCost { get; set; }

    public double ChbottlingLevelOhcost { get; set; }

    public double ChbottlingLevelTotalCost { get; set; }

    public bool ChbottlingLevelTotalCostAdd2TotalCost { get; set; }

    public double ChcoatingLevelCoatingRmcost { get; set; }

    public double ChcoatingLevelShrinkagePercent { get; set; }

    public double ChcoatingLevelShrinkageCost { get; set; }

    public double ChcoatingLevelLaborCost { get; set; }

    public double ChcoatingLevelOhcost { get; set; }

    public double ChcoatingLevelTotalCost { get; set; }

    public bool ChcoatingLevelTotalCostAdd2TotalCost { get; set; }

    public double ChcapsulingLevelPkgCompCost { get; set; }

    public double ChcapsulingLevelShrinkagePercent { get; set; }

    public double ChcapsulingLevelShrinkageCost { get; set; }

    public double ChcapsulingLevelLaborCost { get; set; }

    public double ChcapsulingLevelOhcost { get; set; }

    public double ChcapsulingLevelTotalCost { get; set; }

    public bool ChcapsulingLevelTotalCostAdd2TotalCost { get; set; }

    public double ChgelatinLevelGelatinRmcost { get; set; }

    public double ChgelatinLevelShrinkagePercent { get; set; }

    public double ChgelatinLevelShrinkageCost { get; set; }

    public double ChgelatinLevelLaborCost { get; set; }

    public double ChgelatinLevelOhcost { get; set; }

    public double ChgelatinLevelTotalCost { get; set; }

    public bool ChgelatinLevelTotalCostAdd2TotalCost { get; set; }

    public double ChblisterLevelPkgCompCost { get; set; }

    public double ChblisterLevelShrinkagePercent { get; set; }

    public double ChblisterLevelShrinkageCost { get; set; }

    public double ChblisterLevelLaborCost { get; set; }

    public double ChblisterLevelOhcost { get; set; }

    public double ChblisterLevelTotalCost { get; set; }

    public bool ChblisterLevelTotalCostAdd2TotalCost { get; set; }

    public double ChhandCartoningLaborCost { get; set; }

    public double ChhandCartoningTotalCost { get; set; }

    public bool ChhandCartoningTotalCostAdd2TotalCost { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? ChgelThickness { get; set; }

    public virtual ICollection<CostDetailPackagingEstimateRemove> CostDetailPackagingEstimateRemoves { get; set; } = new List<CostDetailPackagingEstimateRemove>();
}
