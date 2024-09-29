using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class PickTicketHeader
{
    public int PthnoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int PthstatusNoFk { get; set; }

    public string Brlot { get; set; }

    public string Rmcode { get; set; }

    public decimal RmreqQty { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public decimal? RmuseQty { get; set; }

    public string Imcode { get; set; }

    public string LabelClaim { get; set; }

    public decimal? MgPerUnit { get; set; }

    public string Rmnotes { get; set; }

    public int? ShellItemMasterNoFk { get; set; }
}
