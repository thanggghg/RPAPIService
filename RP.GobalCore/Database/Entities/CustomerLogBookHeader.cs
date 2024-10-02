using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerLogBookHeader
{
    public int CustLogHeaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CustomerNoFk { get; set; }

    public string LogUser { get; set; }

    public DateTime LogDate { get; set; }

    public string LogNote { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual ICollection<CustomerLogBookDetail> CustomerLogBookDetails { get; set; } = new List<CustomerLogBookDetail>();

    public virtual Customer CustomerNoFkNavigation { get; set; }
}
