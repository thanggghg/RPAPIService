using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgitemMasterLog
{
    public int FgimlPk { get; set; }

    public int? ItemMasterNoPk { get; set; }

    public int? ImparentLinkFk { get; set; }

    public int? ImnumberOfSiblings { get; set; }

    public string ImsiblingRootId { get; set; }

    public int? RecStatusNoFk { get; set; }

    public string ImcustomerNoFk { get; set; }

    public string ImitemId { get; set; }

    public string ImcustItemId { get; set; }

    public string Imdescription { get; set; }

    public int? ImuomFk { get; set; }

    public int? ImproductClassFk { get; set; }

    public int? ImproductTypeFk { get; set; }

    public double? Imweight { get; set; }

    public double? Imheight { get; set; }

    public double? Imwidth { get; set; }

    public double? Imlength { get; set; }

    public int? Impack { get; set; }

    public int? ImpillSizeNoFk { get; set; }

    public int? ImcolorCodeFk { get; set; }

    public int? ImshapeCodeFk { get; set; }

    public int? ImpillDiceCavityNoFk { get; set; }

    public double? ImgrossWeight { get; set; }

    public double? ImnetWeight { get; set; }

    public double? Imvolume { get; set; }

    public int? ImpalBaseX { get; set; }

    public int? ImpalBaseY { get; set; }

    public int? ImpalHeight { get; set; }

    public double? ImqtyOh { get; set; }

    public double? ImphysicalInventoryQtyOh { get; set; }

    public double? ImqtyAllocated { get; set; }

    public double? ImqtyOrdered { get; set; }

    public double? ImqtyReceived { get; set; }

    public double? ImqtyInPackaging { get; set; }

    public double? ImqtyInQcinspection { get; set; }

    public double? ImqtyWeighedUp { get; set; }

    public double? ImqtyBackOrdered { get; set; }

    public double? ImqtyShipped { get; set; }

    public int? ImglcostCenterNoFk { get; set; }

    public int? ImglcostAcctNoFk { get; set; }

    public int? ImglrevAccountNoFk { get; set; }

    public int? ImglrevSubAccountNoFk { get; set; }

    public double? Imcost { get; set; }

    public decimal? ImavgCost { get; set; }

    public double? ImbookValue { get; set; }

    public string ImformulaNotes { get; set; }

    public string ImpackagingNotes { get; set; }

    public string ImgelatinNotes { get; set; }

    public string ImcoatingNotes { get; set; }

    public string ImcapsuleNotes { get; set; }

    public string Remarks { get; set; }

    public int? ImfgitemMasterBulkIdFk { get; set; }

    public string ImgeneralNotes { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string ImgelType { get; set; }

    public string ImcoatType { get; set; }

    public int? ImcapsuleRmFk { get; set; }

    public string Imupc { get; set; }

    public int? ImcaseQty { get; set; }

    public bool? EdimassMarketItem { get; set; }

    public int? CaseUnitImFk { get; set; }

    public int? ImcomboIdFk { get; set; }

    public string ImitemId6 { get; set; }

    public bool? PilotIm { get; set; }

    public bool? EntericIm { get; set; }

    public bool? ComboIm { get; set; }

    public bool? MixIm { get; set; }

    public bool? PurchaseOrMakeIm { get; set; }

    public double? ImlastPrice { get; set; }

    public DateTime? ImlastPriceDt { get; set; }

    public DateTime? ImavgCostDt { get; set; }

    public decimal? ImstdCost { get; set; }

    public DateTime? ImstdCostDt { get; set; }

    public decimal? ImactualCost { get; set; }

    public DateTime? ImactualCostDt { get; set; }

    public decimal? ImstdPrice { get; set; }

    public DateTime? ImstdPriceDt { get; set; }

    public string ImpackType { get; set; }

    public byte[] Impicture { get; set; }

    public int? ExpireIn { get; set; }
}
