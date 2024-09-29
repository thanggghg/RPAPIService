using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Per
{
    public int PerId { get; set; }

    public string Partner { get; set; }

    public string PerPo { get; set; }

    public DateTime? PerPoDate { get; set; }

    public string Per01ContactCd { get; set; }

    public string Per02Name { get; set; }

    public string Per03CommNumberQ { get; set; }

    public string Per04CommNumber { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
