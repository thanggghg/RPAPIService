using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialByVendor
{
    public int RawMaterialVendorNoPk { get; set; }

    public int RmvrawMaterialNoFk { get; set; }

    public string RmvcustomerNoFk { get; set; }

    public int RmvvendorNoFk { get; set; }

    public string RmvrawMaterialItemNumber { get; set; }

    public string RmvvendorItemNumber { get; set; }

    public int Rmvpack { get; set; }

    public int RmvleadTimeInDays { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Rmvdescription { get; set; }

    public decimal RmvqtyOrdered { get; set; }

    public decimal RmvqtyReceived { get; set; }

    public decimal RmvqtyInQcinspection { get; set; }

    public decimal RmvqtyInProduction { get; set; }

    public decimal RmvqtyOh { get; set; }

    public bool? IsCustSupply { get; set; }

    public decimal RmvqtyExpired { get; set; }

    public decimal RmvqtyReserved { get; set; }

    public int RmvconversionPieces { get; set; }

    public decimal RmvqtyAllocated { get; set; }

    public decimal RmvqtyWeightedUp { get; set; }

    public decimal RmvqtyBackOrdered { get; set; }

    public int RmvpalBaseX { get; set; }

    public int RmvpalBaseY { get; set; }

    public int RmvpalHeight { get; set; }

    public decimal RmvunitCost { get; set; }

    public decimal RmvbookValue { get; set; }

    public decimal RmvstandardCost { get; set; }

    public decimal RmvlastCost { get; set; }

    public decimal RmvgrossWeight { get; set; }

    public decimal RmvnetWeight { get; set; }

    public decimal Rmvheight { get; set; }

    public decimal Rmvwidth { get; set; }

    public decimal Rmvlength { get; set; }

    public decimal Rmvvolume { get; set; }

    public int? RmuomFk { get; set; }

    public decimal? Rmdensity { get; set; }

    public int? RmdensityConversion { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public string CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? RmvminQty { get; set; }

    public decimal? RmvquoteQtyPerStdCost { get; set; }

    public decimal? RmvcasePerPallet { get; set; }

    public DateTime? RmvlastStdCostQuoteDt { get; set; }

    public string RmvlastStdCostQuoteBy { get; set; }

    public string RmvlastStdCostEnterBy { get; set; }

    public bool? Rmvactive { get; set; }

    public string RmvquoteNote { get; set; }

    public string Rmvnote { get; set; }

    public virtual RawMaterial RmvrawMaterialItemNumberNavigation { get; set; }

    public virtual Vendor RmvvendorNoFkNavigation { get; set; }
}
