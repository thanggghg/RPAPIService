using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RawMaterialCoa
{
    public int RmcoaPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RmcoaWhlotNumber { get; set; }

    public string RmcoaItemNumber { get; set; }

    public string RmcoaVendorName { get; set; }

    public string RmcoaApponumber { get; set; }

    public string RmcoaFolder { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string RmdocumentType { get; set; }

    public string ItemDocDirectory { get; set; }
}
