using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm864Mit
{
    public int MitId { get; set; }

    public int? ParentId { get; set; }

    public string Mit01Id { get; set; }

    public string Mit02Description { get; set; }

    public int? Mit03PageWidth { get; set; }

    public int? Mit04PageLength { get; set; }

    public DateTime? GentranTimeStamp { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? CreatedDt { get; set; }
}
