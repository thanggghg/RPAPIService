using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PhysicalInventory
{
    public string ItemCode { get; set; }

    public string WhsLot { get; set; }

    public int NumBox { get; set; }

    public decimal QtyperBox { get; set; }

    public string ItemClass { get; set; }

    public int ProductType { get; set; }

    public decimal TotalQty { get; set; }

    public string PalletId { get; set; }

    public string RackLoc { get; set; }

    public DateTime PhyInvDate { get; set; }

    public string VendorLot { get; set; }

    public string CustCode { get; set; }

    public string VendorName { get; set; }

    public string ItemDesc { get; set; }

    public string WhsLoc { get; set; }

    public decimal RmstandardCost { get; set; }

    public decimal RmlastCost { get; set; }

    public string Note { get; set; }

    public string Reason { get; set; }

    public DateTime? ExpDate { get; set; }

    public DateTime RcvDate { get; set; }

    public string Rmsource { get; set; }
}
