using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860Ref
{
    public int RefId { get; set; }

    public string Partner { get; set; }

    public string RefPo { get; set; }

    public DateTime? RefPoDate { get; set; }

    public string Ref01ReferenceIdentificationQ { get; set; }

    public string Ref02ReferenceIdentification { get; set; }

    public string Ref03Description { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
