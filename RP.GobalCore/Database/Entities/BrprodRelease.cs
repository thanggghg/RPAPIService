using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrprodRelease
{
    public int BrrelPk { get; set; }

    public int BrrelCustomerFk { get; set; }

    public int BrrelBrhFk { get; set; }

    public string Brlot { get; set; }

    public int RecStatusNoFk { get; set; }

    public decimal ProdQty { get; set; }

    public decimal? QtyPerBox { get; set; }

    public int? Boxes { get; set; }

    public int? BoxPerPallet { get; set; }

    public int? Pallets { get; set; }

    public decimal ReleaseQty { get; set; }

    public DateTime? MfgDate { get; set; }

    public string PalletId { get; set; }

    public string Notes { get; set; }

    public string Remark { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? ExpectedPallets { get; set; }

    public byte? BrprstatusFk { get; set; }

    public decimal? DefectiveQty { get; set; }

    public DateTime? QaverifiedDt { get; set; }

    public string QaverifiedBy { get; set; }

    public string ReleasedTo { get; set; }
}
