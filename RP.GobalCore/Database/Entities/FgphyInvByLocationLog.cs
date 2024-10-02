using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgphyInvByLocationLog
{
    public int FgphyInvTransNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int FgphyInvLogItemKeyNoFk { get; set; }

    public int FgphyInvLogCustomerNoFk { get; set; }

    public string FgphyInvLogItemId { get; set; }

    public decimal FgphyInvLogItemPack { get; set; }

    public string FgphyInvLogItemDesc { get; set; }

    public decimal FgphyInvLogQty { get; set; }

    public string FgphyInvLogWhsLot { get; set; }

    public string FgphyInvLogManLot { get; set; }

    public string FgphyInvLogVendorId { get; set; }

    public string FgphyInvLogFromLocation { get; set; }

    public string FgphyInvLogToLocation { get; set; }

    public string FgphyInvLogOperation { get; set; }

    public int FgphyInvLogProductTypeClass { get; set; }

    public string FgphyInvLogUom { get; set; }

    public decimal FgphyInvLogQtyPerBox { get; set; }

    public int FgphyInvLogNumBox { get; set; }

    public string FgphyInvLogNotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string FgphyInvLogWhsLocation { get; set; }

    public string FgphyInvLogReason { get; set; }

    public decimal? PkgReturnWhsQty { get; set; }

    public string PalletId { get; set; }
}
