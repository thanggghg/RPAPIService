using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Fgcoa
{
    public int FgcoaPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string FgcoaLotNumber { get; set; }

    public string FgcoaItemId { get; set; }

    public int FgcoaItemFk { get; set; }

    public string FgcoaFolder { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string FgdocumentType { get; set; }

    public int? PkgBatchNumber { get; set; }

    public string ItemDocDirectory { get; set; }
}
