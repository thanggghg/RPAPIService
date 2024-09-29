using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgitemMasterBulkId
{
    public int ImbulkIdheaderPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int ImbulkIdfgitemMasterFk { get; set; }

    public decimal ImbulkIdfgitemMasterVer { get; set; }

    public int ImbulkIdrnDfmlRootId { get; set; }

    public string ImbulkIdfgformulaNumber { get; set; }

    public int? ImbulkIdgelFmlItemMasterFk { get; set; }

    public int ImbulkIdrnDheaderFk { get; set; }

    public int? ImbulkIdcoatFmlItemMasterFk { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
