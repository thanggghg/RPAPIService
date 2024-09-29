using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Soheader
{
    public int SoheaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int SohstatusNoFk { get; set; }

    public int? SohorderSrc { get; set; }

    public string SohedipartnerId { get; set; }

    public DateTime? SoheditimeStamp { get; set; }

    public bool? SohstockItem { get; set; }

    public bool Sohbrcreated { get; set; }

    public DateTime? SohbrcreatedDt { get; set; }

    public bool Sohbomcreated { get; set; }

    public DateTime? SohbomcreatedDt { get; set; }

    public string SohcustomerNoFk { get; set; }

    public int SohbillToNoFk { get; set; }

    public int SohshipToNoFk { get; set; }

    public int? SohquoteHeaderNoFk { get; set; }

    public string SohcustPonumber { get; set; }

    public DateTime Sohpodate { get; set; }

    public DateTime Sohsodate { get; set; }

    public DateTime? SohdueDate { get; set; }

    public string SohdueIn { get; set; }

    public string Sohfob { get; set; }

    public string SohsortedKey { get; set; }

    public int? SohtermNoFk { get; set; }

    public double SohproductionTotalQty { get; set; }

    public double? SohorderedSalesTax { get; set; }

    public double? SohtotalAmount { get; set; }

    public string SohconfirmedAttn { get; set; }

    public string SohconfirmedFax { get; set; }

    public string SohconfirmedEmail { get; set; }

    public string Sohfax { get; set; }

    public string Sohrep { get; set; }

    public string SohsalesRep { get; set; }

    public string Sohnotes { get; set; }

    public bool SohproductionScheduled { get; set; }

    public DateTime? SohproductionScheduledStartDt { get; set; }

    public DateTime? SohproductionScheduledEndDt { get; set; }

    public bool SohbatchProduction { get; set; }

    public DateTime? SohbatchProductionStartDt { get; set; }

    public DateTime? SohbatchProductionEndDt { get; set; }

    public bool SohbatchWeighedUp { get; set; }

    public DateTime? SohweighedUpStartDate { get; set; }

    public DateTime? SohweighedUpEndDate { get; set; }

    public bool SohbatchBlending { get; set; }

    public DateTime? SohbatchBlendingStartDt { get; set; }

    public DateTime? SohbatchBlendingEndDt { get; set; }

    public bool SohbatchCompressing { get; set; }

    public DateTime? SohbatchCompressingStartDt { get; set; }

    public DateTime? SohbatchCompressingEndDt { get; set; }

    public bool SohbatchCoating { get; set; }

    public DateTime? SohbatchCoatingStartDt { get; set; }

    public DateTime? SohbatchCoatingEndDt { get; set; }

    public bool SohbatchInspection { get; set; }

    public DateTime? SohbatchInspectionStartDt { get; set; }

    public DateTime? SohbatchInspectionEndDt { get; set; }

    public bool SohbatchMixing { get; set; }

    public DateTime? SohbatchMixingStartDt { get; set; }

    public DateTime? SohbatchMixingEndDt { get; set; }

    public bool SohbatchEncapsulation { get; set; }

    public DateTime? SohbatchEncapsulationStartDt { get; set; }

    public DateTime? SohbatchEncapsulationEndDt { get; set; }

    public bool SohbatchDrying { get; set; }

    public DateTime? SohbatchDryingStartDt { get; set; }

    public DateTime? SohbatchDryingEndDt { get; set; }

    public bool SohbatchCountingNsorting { get; set; }

    public DateTime? SohbatchCountingNsortingStartDt { get; set; }

    public DateTime? SohbatchCountingNsortingEndDt { get; set; }

    public bool SohbatchPolishing { get; set; }

    public DateTime? SohbatchPolishingStartDt { get; set; }

    public DateTime? SohbatchPolishingEndDt { get; set; }

    public bool SohbatchQareleased { get; set; }

    public DateTime? SohbatchQareleasedStartDt { get; set; }

    public DateTime? SohbatchQareleasedEndDt { get; set; }

    public bool SohbatchLabelPrinting { get; set; }

    public DateTime? SohbatchLabelPrintingStartDt { get; set; }

    public DateTime? SohbatchLabelPrintingEndDt { get; set; }

    public bool SohbatchPackaging { get; set; }

    public bool? SohpackagingCompleted { get; set; }

    public DateTime? SohbatchPackagingStartDt { get; set; }

    public DateTime? SohbatchPackagingEndDt { get; set; }

    public bool SohproductionReleasedFlag { get; set; }

    public DateTime? SohproductionReleasedStartDt { get; set; }

    public DateTime? SohproductionReleasedEndDt { get; set; }

    public bool SohproductionCompleted { get; set; }

    public DateTime? SohproductionCompletedDt { get; set; }

    public bool SohisShipmentStart { get; set; }

    public DateTime? SohshipmentStartDt { get; set; }

    public DateTime? SohsoclosedDt { get; set; }

    public string SohsoclosedBy { get; set; }

    public string Sohremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public DateTime? SohsovoidedDt { get; set; }

    public string SohsovoidedBy { get; set; }

    public string SohediDuns { get; set; }

    public string SohediVendorId { get; set; }

    public decimal? SohextraFee { get; set; }

    public bool SohpkgBomcreated { get; set; }

    public DateTime? SohpkgBomcreatedDt { get; set; }

    public string SohsalesRep2 { get; set; }

    public DateTime? SoconfirmDt { get; set; }

    public string SoconfirmBy { get; set; }

    public bool? CancelByCust { get; set; }

    public string SohcustNotes { get; set; }

    public DateTime? SopkgConfirmDt { get; set; }

    public string SopkgConfirmBy { get; set; }

    public DateTime? SodueConfirmDt { get; set; }

    public string SodueConfirmBy { get; set; }

    public virtual ICollection<Sodetail> Sodetails { get; set; } = new List<Sodetail>();

    public virtual ICollection<Sopodetail> Sopodetails { get; set; } = new List<Sopodetail>();
}
