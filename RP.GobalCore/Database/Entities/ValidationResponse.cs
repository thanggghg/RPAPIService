using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ValidationResponse
{
    public int ValidationResponseNoPk { get; set; }

    public int KeyNoFk { get; set; }

    public string ValidationCode { get; set; }

    public int VoptionNoFk { get; set; }

    public string VerifedReason { get; set; }

    public string VerifiedValue { get; set; }

    public string VerifiedBy { get; set; }

    public DateTime VerifiedDt { get; set; }

    public string TableName { get; set; }

    public string FieldKeyName { get; set; }

    public virtual ValidationOption VoptionNoFkNavigation { get; set; }
}
