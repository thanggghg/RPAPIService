using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class GelBatchHeader
{
    public int GbheaderPk { get; set; }

    public string Brlot { get; set; }

    public string Imcode { get; set; }

    public decimal Imver { get; set; }

    public string Imdesc { get; set; }

    public string GelColorImcode { get; set; }

    public string GelColorImdesc { get; set; }

    public decimal GelVer { get; set; }

    public string GelMassCode { get; set; }

    public string GelSource { get; set; }

    public decimal GelCookQty { get; set; }

    public string GelBatchLot { get; set; }

    public int RecStatusNoFk { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }

    public int? Gbstatus { get; set; }

    public string Gbroom { get; set; }

    public string Note { get; set; }

    public DateTime? GelCookStartDt { get; set; }

    public DateTime? GelCookEndDt { get; set; }
}
