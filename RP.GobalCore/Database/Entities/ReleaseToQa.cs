using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ReleaseToQa
{
    public int SoheaderNoPk { get; set; }

    public string SohcustPonumber { get; set; }

    public string ImitemId { get; set; }

    public string Imdescription { get; set; }

    public string CustomerName { get; set; }

    public string BrhlotNumber { get; set; }

    public decimal BrhlotSize { get; set; }

    public DateTime? BrhproductionCompletedDt { get; set; }

    public DateTime? SohdueDate { get; set; }

    public DateTime? MfgDate { get; set; }

    public decimal? TotalQty { get; set; }

    public int BrhstatusNoFk { get; set; }

    public decimal? ToDateRelQty { get; set; }

    public int ProductType { get; set; }
}
