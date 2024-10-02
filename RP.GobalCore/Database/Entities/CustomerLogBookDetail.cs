using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerLogBookDetail
{
    public int CustLogDetailNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int CustLogHdrFk { get; set; }

    public string DlogUser { get; set; }

    public DateTime DlogDate { get; set; }

    public string DlogNote { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual CustomerLogBookHeader CustLogHdrFkNavigation { get; set; }
}
