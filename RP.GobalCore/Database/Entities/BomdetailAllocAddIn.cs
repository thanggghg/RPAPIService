using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BomdetailAllocAddIn
{
    public int BomallocAddInHeaderPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? BomheaderFk { get; set; }

    public string Brlot { get; set; }

    public string Rmcode { get; set; }

    public int RmitemFk { get; set; }

    public decimal AdjQty { get; set; }

    public string Notes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? Sonum { get; set; }

    public string Imcode { get; set; }

    public virtual Bomheader BomheaderFkNavigation { get; set; }
}
