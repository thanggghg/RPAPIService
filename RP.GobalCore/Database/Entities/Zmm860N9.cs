using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860N9
{
    public int N9id { get; set; }

    public string Partner { get; set; }

    public string N9po { get; set; }

    public DateTime? N9poDate { get; set; }

    public string N901ReferenceIdentificationQ { get; set; }

    public string N092ReferenceIdentification { get; set; }

    public string Mtx02Text { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
