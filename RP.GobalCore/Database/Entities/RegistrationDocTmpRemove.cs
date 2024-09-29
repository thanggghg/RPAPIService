using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RegistrationDocTmpRemove
{
    public int ItemDocPk { get; set; }

    public string ItemCode { get; set; }

    public string ItemDocDirectory { get; set; }

    public string VendorName { get; set; }

    public string FName { get; set; }
}
