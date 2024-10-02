using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgphyInvByLocation
{
    public int FgitemByLocNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int FgitemByLocCustomerNoFk { get; set; }

    public int FgitemByLocItemMasterNoFk { get; set; }

    public decimal FgitemByLocQty { get; set; }

    public double? FgitemByLocConversionQty { get; set; }

    public int? FgitemByLocConversionPieces { get; set; }

    public string FgitemByLocItemId { get; set; }

    public decimal FgitemByLocItemPack { get; set; }

    public string FgitemByLocItemDesc { get; set; }

    public string FgitemByLocWhsLot { get; set; }

    public string FgitemByLocManLot { get; set; }

    public string FgitemByLocations { get; set; }

    public string FgitemByLocUom { get; set; }

    public int FgitemByLocNumBox { get; set; }

    public decimal FgitemByLocQtyPerBox { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string FgitemByLocWhsLocation { get; set; }

    public string FgitemByLocReason { get; set; }

    public decimal? PkgReturnWhsQty { get; set; }

    public string FgbyLocNotes { get; set; }

    public string PalletId { get; set; }
}
