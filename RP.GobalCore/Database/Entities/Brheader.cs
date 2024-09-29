using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Brheader
{
    public int BatchRecordHeaderNoPk { get; set; }

    public int BrhbatchRecordTypeNoFk { get; set; }

    /// <summary>
    /// BR id from Master Batch Record
    /// </summary>
    public int? BatchRecordId { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrhstatusNoFk { get; set; }

    public int BrhsodetailNoFk { get; set; }

    public int BrhsoheaderNoFk { get; set; }

    public string BrhlotNumber { get; set; }

    public DateOnly? BrhdueDate { get; set; }

    public string BrhconvertedFromLotNumber { get; set; }

    public string BrhlotNumberSortedKey { get; set; }

    public decimal BrhlotSize { get; set; }

    public int? BrhlatestProdStatus { get; set; }

    public DateTime? BrhlatestProdStatusDt { get; set; }

    public bool BrhbatchEdited { get; set; }

    public DateTime? BrhbatchEditedDt { get; set; }

    public bool BrhproductionScheduled { get; set; }

    public DateTime? BrhproductionScheduledStartDt { get; set; }

    public DateTime? BrhproductionScheduledEndDt { get; set; }

    public bool BrhbatchReleased2Prod { get; set; }

    public DateTime? BrhbatchReleased2ProdStartDt { get; set; }

    public DateTime? BrhbatchReleased2ProdEndDt { get; set; }

    public bool BrhbatchProduction { get; set; }

    public DateTime? BrhbatchProductionStartDt { get; set; }

    public DateTime? BrhbatchProductionEndDt { get; set; }

    public bool BrhbatchWeighedUp { get; set; }

    public DateTime? BrhbatchWeighedUpStartDt { get; set; }

    public DateTime? BrhbatchWeighedUpEndDt { get; set; }

    public bool BrhbatchBlending { get; set; }

    public DateTime? BrhbatchBlendingStartDt { get; set; }

    public DateTime? BrhbatchBlendingEndDt { get; set; }

    public bool BrhgelMixing { get; set; }

    public DateTime? BrhgelMixingStartDt { get; set; }

    public DateTime? BrhgelMixingEndDt { get; set; }

    public bool BrhbatchCompressing { get; set; }

    public DateTime? BrhbatchCompressingStartDt { get; set; }

    public DateTime? BrhbatchCompressingEndDt { get; set; }

    public bool BrhbatchCoating { get; set; }

    public DateTime? BrhbatchCoatingStartDt { get; set; }

    public DateTime? BrhbatchCoatingEndDt { get; set; }

    public bool BrhbatchInspection { get; set; }

    public DateTime? BrhbatchInspectionStartDt { get; set; }

    public DateTime? BrhbatchInspectionEndDt { get; set; }

    public bool BrhbatchMixing { get; set; }

    public DateTime? BrhbatchMixingStartDt { get; set; }

    public DateTime? BrhbatchMixingEndDt { get; set; }

    public bool BrhbatchEncapsulation { get; set; }

    public DateTime? BrhbatchEncapsulationStartDt { get; set; }

    public DateTime? BrhbatchEncapsulationEndDt { get; set; }

    public bool BrhbatchDrying { get; set; }

    public DateTime? BrhbatchDryingStartDt { get; set; }

    public DateTime? BrhbatchDryingEndDt { get; set; }

    public bool BrhbatchCountingNsorting { get; set; }

    public DateTime? BrhbatchCountingNsortingStartDt { get; set; }

    public DateTime? BrhbatchCountingNsortingEndDt { get; set; }

    public bool BrhbatchPolishing { get; set; }

    public DateTime? BrhbatchPolishingStartDt { get; set; }

    public DateTime? BrhbatchPolishingEndDt { get; set; }

    public bool BrhbatchQareleased { get; set; }

    public DateTime? BrhbatchQareleasedStartDt { get; set; }

    public DateTime? BrhbatchQareleasedEndDt { get; set; }

    public bool BrhbatchLabelPrinting { get; set; }

    public DateTime? BrhbatchLabelPrintingStartDt { get; set; }

    public DateTime? BrhbatchLabelPrintingEndDt { get; set; }

    public bool? BrhbatchPackaging { get; set; }

    public bool BrhpackagingCompleted { get; set; }

    public DateTime? BrhbatchPackagingStartDt { get; set; }

    public DateTime? BrhbatchPackagingEndDt { get; set; }

    public bool Brhbr2productionFlag { get; set; }

    public DateTime? Brhbr2productionDate { get; set; }

    public int BrhproductionReleasedSize { get; set; }

    public int BrhproductionPackedSize { get; set; }

    public bool BrhproductionReleasedFlag { get; set; }

    public DateTime? BrhproductionReleasedStartDt { get; set; }

    public DateTime? BrhproductionReleasedEndDt { get; set; }

    public bool BrhproductionCompleted { get; set; }

    public DateTime? BrhproductionCompletedDt { get; set; }

    public int BrhshipmentSize { get; set; }

    public bool BrhisShipmentStart { get; set; }

    public DateTime? BrhshipmentStartDt { get; set; }

    public double BrhlotTotalWeight { get; set; }

    public double? BrhlotActualWeight { get; set; }

    public string Brhnotes { get; set; }

    public bool BrhalreadyWeighedUp { get; set; }

    public bool? BrhstockItem { get; set; }

    public string SpComment { get; set; }

    public string LotComment { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? BrhreclaimedQty { get; set; }

    public bool? BrhmanualCreated { get; set; }

    public bool? Brhenteric { get; set; }

    public int? Brhcoating { get; set; }

    public int? BrhnewLotSize { get; set; }

    public string Bmebatch { get; set; }

    public decimal? BrhencapsulatedQty { get; set; }

    public decimal? BrhcoatedQty { get; set; }

    public decimal? BrhinspectedQty { get; set; }

    public int Bversion { get; set; }
}
