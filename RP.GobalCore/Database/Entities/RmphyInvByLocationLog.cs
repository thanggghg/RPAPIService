using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmphyInvByLocationLog
{
    public int RmphyInvTransNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmphyInvLogItemKeyNoFk { get; set; }

    public int RmphyInvLogVendorNoFk { get; set; }

    public string RmphyInvLogItemId { get; set; }

    public int RmphyInvLogItemPack { get; set; }

    public string RmphyInvLogItemDesc { get; set; }

    public decimal RmphyInvLogQty { get; set; }

    public string RmphyInvLogWhsLot { get; set; }

    public string RmphyInvLogVendorLot { get; set; }

    public string RmphyInvLogFromLocation { get; set; }

    public string RmphyInvLogToLocation { get; set; }

    public string RmphyInvLogOperation { get; set; }

    public int RmphyInvLogProductTypeClass { get; set; }

    public decimal RmphyInvLogQtyPerBox { get; set; }

    public int RmphyInvLogNumBox { get; set; }

    public string RmphyInvLogNotes { get; set; }

    public string RmphyInvLogWhsLocation { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string RmphyInvLogVendorCode { get; set; }

    public string RmphyInvLogReason { get; set; }

    public decimal? PkgReturnWhsQty { get; set; }

    public string PalletId { get; set; }
}
