using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Sodetail
{
    public int SodetailNoPk { get; set; }

    public int SodsoheaderNoFk { get; set; }

    public int? SodquoteHeaderNoFk { get; set; }

    public int? SodquoteDetailNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string SoditemId { get; set; }

    public double SodproductionQty { get; set; }

    public int SoditemMasterNoFk { get; set; }

    public double SodcustomerOrderQty { get; set; }

    public double SodcostPerThousand { get; set; }

    public double SodextCost { get; set; }

    public double SodpricePerThousand { get; set; }

    public double SodextPrice { get; set; }

    public int? SodstatusNoFk { get; set; }

    public bool SodpackagingSetup { get; set; }

    public DateTime? SodpackagingSetupDate { get; set; }

    public bool Sodbrcreated { get; set; }

    public DateTime? SodbrcreatedDt { get; set; }

    public bool Sodbomcreated { get; set; }

    public DateTime? SodbomcreatedDt { get; set; }

    public DateTime? SoddeliveredDate { get; set; }

    public string SodcustItemId { get; set; }

    public string SodimcustomerNoFk { get; set; }

    public double SodtotalRmweight { get; set; }

    public int? SodorderedUomFk { get; set; }

    public double SodcostPerPackSize { get; set; }

    public double SodpricePerPackSize { get; set; }

    public string Sodnotes { get; set; }

    public bool SodproductionScheduled { get; set; }

    public DateTime? SodproductionScheduledStartDt { get; set; }

    public DateTime? SodproductionScheduledEndDt { get; set; }

    public bool SodbatchProduction { get; set; }

    public DateTime? SodbatchProductionStartDt { get; set; }

    public DateTime? SodbatchProductionEndDt { get; set; }

    public bool SodbatchWeighedUp { get; set; }

    public DateTime? SodbatchWeighedUpStartDt { get; set; }

    public DateTime? SodbatchWeighedUpEndDt { get; set; }

    public bool SodbatchBlending { get; set; }

    public DateTime? SodbatchBlendingStartDt { get; set; }

    public DateTime? SodbatchBlendingEndDt { get; set; }

    public bool SodbatchCompressing { get; set; }

    public DateTime? SodbatchCompressingStartDt { get; set; }

    public DateTime? SodbatchCompressingEndDt { get; set; }

    public bool SodbatchCoating { get; set; }

    public DateTime? SodbatchCoatingStartDt { get; set; }

    public DateTime? SodbatchCoatingEndDt { get; set; }

    public bool SodbatchInspection { get; set; }

    public DateTime? SodbatchInspectionStartDt { get; set; }

    public string SodbatchInspectionEndDt { get; set; }

    public bool SodbatchMixing { get; set; }

    public DateTime? SodbatchMixingStartDt { get; set; }

    public DateTime? SodbatchMixingEndDt { get; set; }

    public bool SodbatchEncapsulation { get; set; }

    public DateTime? SodbatchEncapsulationStartDt { get; set; }

    public DateTime? SodbatchEncapsulationEndDt { get; set; }

    public bool SodbatchDrying { get; set; }

    public DateTime? SodbatchDryingStartDt { get; set; }

    public DateTime? SodbatchDryingEndDt { get; set; }

    public bool SodbatchCountingNsorting { get; set; }

    public DateTime? SodbatchCountingNsortingStartDt { get; set; }

    public DateTime? SodbatchCountingNsortingEndDt { get; set; }

    public bool SodbatchPolishing { get; set; }

    public DateTime? SodbatchPolishingStartDt { get; set; }

    public DateTime? SodbatchPolishingEndDt { get; set; }

    public bool SodbatchQareleased { get; set; }

    public DateTime? SodbatchQareleasedStartDt { get; set; }

    public DateTime? SodbatchQareleasedEndDt { get; set; }

    public bool SodbatchLabelPrinting { get; set; }

    public DateTime? SodbatchLabelPrintingStartDt { get; set; }

    public DateTime? SodbatchLabelPrintingEndDt { get; set; }

    public bool SodbatchPackaging { get; set; }

    public bool? SodpackagingCompleted { get; set; }

    public DateTime? SodbatchPackagingStartDt { get; set; }

    public DateTime? SodbatchPackagingEndDt { get; set; }

    public bool SodproductionCompleted { get; set; }

    public DateTime? SodproductionCompletedDt { get; set; }

    public bool SodproductionReleasedFlag { get; set; }

    public double? SodproductionReleasedSize { get; set; }

    public DateTime? SodproductionReleasedStartDt { get; set; }

    public DateTime? SodproductionReleasedEndDt { get; set; }

    public bool SodisShipmentStart { get; set; }

    public DateTime? SodshipmentStartDt { get; set; }

    public string Sodremarks { get; set; }

    public decimal? SoditemMasterVer { get; set; }

    public bool? IsBlanketPo { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? Sodrework { get; set; }

    public string SoditemId6 { get; set; }

    public double? SodnewQty { get; set; }

    public virtual FgitemMaster SoditemMasterNoFkNavigation { get; set; }

    public virtual Soheader SodsoheaderNoFkNavigation { get; set; }
}
