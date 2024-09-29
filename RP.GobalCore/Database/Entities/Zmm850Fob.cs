using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Fob
{
    public int FobId { get; set; }

    public string Partner { get; set; }

    public string FobPo { get; set; }

    public DateTime? FobPoDate { get; set; }

    public string Fob01MethodOfPayment { get; set; }

    public string Fob02LocationQ { get; set; }

    public string Fob03Description { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
