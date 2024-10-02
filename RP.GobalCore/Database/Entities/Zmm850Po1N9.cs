using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Po1N9
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string N9po { get; set; }

    public DateTime? N9poDate { get; set; }

    public string N9poitemLineNumber { get; set; }

    public string N901ReferenceIdentificationQ { get; set; }

    public string N092ReferenceIdentification { get; set; }

    public string Mtx02Text { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
