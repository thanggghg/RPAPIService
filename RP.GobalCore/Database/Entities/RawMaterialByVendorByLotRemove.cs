using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialByVendorByLotRemove
{
    public int RminvLotNoPk { get; set; }

    public int RmvlrawMaterialNoFk { get; set; }

    public string RmitemNumber { get; set; }

    public string RmvlwhsLotNumber { get; set; }

    public bool? IsCustSupply { get; set; }

    public string CustId { get; set; }

    public string RmvlvendorLotNumber { get; set; }

    public string RmvlwhsOldLotNumber { get; set; }

    public int RmvlvendorNoFk { get; set; }

    public DateTime? RmvlexpiredDate { get; set; }

    public bool Rmvlverified { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal RmvlqtyOrdered { get; set; }

    public decimal RmvlqtyInQcinspection { get; set; }

    public decimal RmvlqtyInProduction { get; set; }

    public decimal RmvlqtyRecv { get; set; }

    public decimal RmvlqtyOh { get; set; }

    public decimal RmvlphysicalInventoryQtyOh { get; set; }

    public decimal RmvlconversionQtyOh { get; set; }

    public int RmvlconversionPieces { get; set; }

    public decimal RmvlqtyAllocated { get; set; }

    public decimal RmvlqtyWeighedUp { get; set; }

    public decimal RmvlqtyBackOrdered { get; set; }

    public string Rmvlnotes { get; set; }

    public string Rmvlremarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string XferFromRmcode { get; set; }

    public string XferBy { get; set; }

    public DateTime? XferDt { get; set; }

    public string RmvlretestBy { get; set; }

    public DateTime? RmvlretestDate { get; set; }

    public int? RmvlretestStatus { get; set; }
}
