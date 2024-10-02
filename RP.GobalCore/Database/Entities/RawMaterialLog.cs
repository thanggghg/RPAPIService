using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialLog
{
    public int Logid { get; set; }

    public int RawMaterialNoPk { get; set; }

    public string RmitemNumber { get; set; }

    public int Rmpack { get; set; }

    public int RmuomFk { get; set; }

    public bool RmcustomerSupplied { get; set; }

    public int RmproductClassNoFk { get; set; }

    public int RmproductTypeNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RmcustomerNoFk { get; set; }

    public string Rmdescription { get; set; }

    public decimal RmqtyOrdered { get; set; }

    public decimal RmqtyReceived { get; set; }

    public decimal RmqtyShipped { get; set; }

    public decimal RmqtyInQcinspection { get; set; }

    public decimal RmqtyInProduction { get; set; }

    public decimal RmqtyOh { get; set; }

    public decimal RmqtyExpired { get; set; }

    public decimal RmqtyReserved { get; set; }

    public int RmconversionPieces { get; set; }

    public decimal RmqtyAllocated { get; set; }

    public decimal RmqtyToBePurchased { get; set; }

    public decimal RmqtyWeightedUp { get; set; }

    public decimal RmqtyBackOrdered { get; set; }

    public int? RmpalBaseX { get; set; }

    public int? RmpalBaseY { get; set; }

    public int? RmpalHeight { get; set; }

    public int RmunitCostFactor { get; set; }

    public decimal RmunitCost { get; set; }

    public decimal? RmbookValue { get; set; }

    public decimal RmstandardCost { get; set; }

    public decimal RmlastCost { get; set; }

    public decimal? RmgrossWeight { get; set; }

    public decimal? RmnetWeight { get; set; }

    public decimal? Rmheight { get; set; }

    public decimal? Rmwidth { get; set; }

    public decimal? Rmlength { get; set; }

    public decimal? Rmvolume { get; set; }

    public string RmglcostCenterNoFk { get; set; }

    public string RmglcostAccountNoFk { get; set; }

    public string RmglrevAccountNoFk { get; set; }

    public string RmglrevSubAccountNoFk { get; set; }

    public string ExternalDescription { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public string CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string RmpkgVer { get; set; }

    public int? RmpkgCount { get; set; }

    public int? RmpkgCategoryNoFk { get; set; }

    public string RmpkgProdType { get; set; }

    public DateTime? RmlastStdCostDate { get; set; }

    public string RmcustItem { get; set; }

    public string Notes { get; set; }

    public decimal? RmminQtyPur { get; set; }

    public decimal? RmminQtyInStock { get; set; }

    public string RmchemName { get; set; }

    public string RmlatinName { get; set; }

    public string RmbrandName { get; set; }

    public string RmpotencyName { get; set; }

    public bool? Rmdiscontinue { get; set; }

    public string RmlastStdCostBy { get; set; }

    public bool? RmneedManualOrder { get; set; }

    public DateTime? RmlastPodate { get; set; }

    public bool? Halal { get; set; }

    public string Category { get; set; }

    public string PlantPart { get; set; }

    public string Carrier { get; set; }

    public string Devision { get; set; }

    public decimal? RmlastApcost { get; set; }

    public DateTime? RmlastApdate { get; set; }

    public string ActiveIngredient { get; set; }
}
