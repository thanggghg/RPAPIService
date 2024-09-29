using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgitemMaster
{
    public int ItemMasterNoPk { get; set; }

    public int? ImparentLinkFk { get; set; }

    public int? ImnumberOfSiblings { get; set; }

    public string ImsiblingRootId { get; set; }

    public int RecStatusNoFk { get; set; }

    public string ImcustomerNoFk { get; set; }

    public string ImitemId { get; set; }

    public string ImcustItemId { get; set; }

    public string Imdescription { get; set; }

    public int? ImuomFk { get; set; }

    public int ImproductClassFk { get; set; }

    public int ImproductTypeFk { get; set; }

    public float Imweight { get; set; }

    public float Imheight { get; set; }

    public float Imwidth { get; set; }

    public float Imlength { get; set; }

    public float Impack { get; set; }

    public int? ImpillSizeNoFk { get; set; }

    public int ImcolorCodeFk { get; set; }

    public int? ImshapeCodeFk { get; set; }

    public int? ImpillDiceCavityNoFk { get; set; }

    public float ImgrossWeight { get; set; }

    public float ImnetWeight { get; set; }

    public float Imvolume { get; set; }

    public int ImpalBaseX { get; set; }

    public int ImpalBaseY { get; set; }

    public int ImpalHeight { get; set; }

    public decimal ImqtyOh { get; set; }

    public float ImphysicalInventoryQtyOh { get; set; }

    public decimal ImqtyAllocated { get; set; }

    public decimal ImqtyOrdered { get; set; }

    public float ImqtyReceived { get; set; }

    public float ImqtyInPackaging { get; set; }

    public decimal ImqtyInQcinspection { get; set; }

    public float ImqtyWeighedUp { get; set; }

    public float ImqtyBackOrdered { get; set; }

    public float ImqtyShipped { get; set; }

    public int? ImglcostCenterNoFk { get; set; }

    public int? ImglcostAcctNoFk { get; set; }

    public int? ImglrevAccountNoFk { get; set; }

    public int? ImglrevSubAccountNoFk { get; set; }

    public float Imcost { get; set; }

    public float ImavgCost { get; set; }

    public float ImbookValue { get; set; }

    public string ImformulaNotes { get; set; }

    public string ImpackagingNotes { get; set; }

    public string ImgelatinNotes { get; set; }

    public string ImcoatingNotes { get; set; }

    public string ImcapsuleNotes { get; set; }

    public string Remarks { get; set; }

    public int? ImfgitemMasterBulkIdFk { get; set; }

    public string ImgeneralNotes { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public string ImgelType { get; set; }

    public string ImcoatType { get; set; }

    public int? ImcapsuleRmFk { get; set; }

    public string Imupc { get; set; }

    public int? ImcaseQty { get; set; }

    public bool EdimassMarketItem { get; set; }

    public int? CaseUnitImFk { get; set; }

    public int? ImcomboIdFk { get; set; }

    public string ImitemId6 { get; set; }

    public bool? PilotIm { get; set; }

    public bool? EntericIm { get; set; }

    public bool? ComboIm { get; set; }

    public bool? MixIm { get; set; }

    public bool? PurchaseOrMakeIm { get; set; }

    public float? ImlastPrice { get; set; }

    public DateTime? ImlastPriceDt { get; set; }

    public DateTime? ImavgCostDt { get; set; }

    public float? ImstdCost { get; set; }

    public DateTime? ImstdCostDt { get; set; }

    public float? ImactualCost { get; set; }

    public DateTime? ImactualCostDt { get; set; }

    public float? ImstdPrice { get; set; }

    public DateTime? ImstdPriceDt { get; set; }

    public string ImpackType { get; set; }

    public byte[] Impicture { get; set; }

    public int? ExpireIn { get; set; }

    public virtual ICollection<FgpkgComponent> FgpkgComponents { get; set; } = new List<FgpkgComponent>();

    public virtual ColorCode ImcolorCodeFkNavigation { get; set; }

    public virtual Customer ImcustomerNoFkNavigation { get; set; }

    public virtual PillSize ImpillSizeNoFkNavigation { get; set; }

    public virtual ShapeCode ImshapeCodeFkNavigation { get; set; }

    public virtual ICollection<Sodetail> Sodetails { get; set; } = new List<Sodetail>();
}
