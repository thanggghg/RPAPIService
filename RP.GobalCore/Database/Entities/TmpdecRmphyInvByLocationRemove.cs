using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TmpdecRmphyInvByLocationRemove
{
    public int RmitemByLocNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmitemByLocRmitemNoFk { get; set; }

    public string RmitemByLocItemId { get; set; }

    public string RmitemByLocItemDesc { get; set; }

    public string RmitemByLocWhsLot { get; set; }

    public string RmitemByLocVendorLot { get; set; }

    public int RmitemByLocVendorNoFk { get; set; }

    public int RmitemByLocNumBox { get; set; }

    public decimal RmitemByLocQtyPerBox { get; set; }

    public decimal RmitemByLocQty { get; set; }

    public string RmitemByLocations { get; set; }

    public int RmitemByLocProductClassNoFk { get; set; }

    public string RmitemByLocWhsLocation { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string RmbyLocNotes { get; set; }

    public string RmbyLocVendorCode { get; set; }

    public string RmbyLocReason { get; set; }

    public decimal? PkgReturnWhsQty { get; set; }

    public string PalletId { get; set; }
}
