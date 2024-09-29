using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Brdetail
{
    public int BatchRecordDetailNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BrdstatusNoFk { get; set; }

    public int BrdheaderNoFk { get; set; }

    public int BrdtankNumber { get; set; }

    public string BrdtankNumberSortedKey { get; set; }

    public int BrdtankSize { get; set; }

    public double BrdtankWeight { get; set; }

    public string Brdnotes { get; set; }

    public bool BrdweighedUp { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? BrdtankStatus { get; set; }

    public DateTime? BrdtankWuendDt { get; set; }

    public string Brdroom { get; set; }

    public string BrdlotNumber { get; set; }

    public DateTime? BrdtankBlendingStartDt { get; set; }

    public DateTime? BrdtankBlendingEndDt { get; set; }

    public DateTime? BrdtankWustartDt { get; set; }

    public DateTime? BrdtankEncapsulationStartDt { get; set; }

    public DateTime? BrdtankEncapsulationEndDt { get; set; }

    public DateTime? BrdtankCoatingStartDt { get; set; }

    public DateTime? BrdtankCoatingEndDt { get; set; }

    public DateTime? BrdtankInspectionStartDt { get; set; }

    public DateTime? BrdtankInspectionEndDt { get; set; }

    public decimal? BrdtankEncapsulationQty { get; set; }

    public decimal? BrdtankCoatingQty { get; set; }

    public decimal? BrdtankInspectionQty { get; set; }

    public DateTime? BrdtankSluggingStartDt { get; set; }

    public DateTime? BrdtankSluggingEndDt { get; set; }

    public string BrdtankSluggingPercentage { get; set; }

    public string BrdtankBlendingId { get; set; }

    public int? BrdroomOrder { get; set; }

    public int? BrdtankInspectionHour { get; set; }

    public string BrdlastStageUpdBy { get; set; }

    public DateTime? BrdlastStageUpdDt { get; set; }
}
