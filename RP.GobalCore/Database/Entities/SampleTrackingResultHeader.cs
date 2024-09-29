using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingResultHeader
{
    public int RmthnoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmtFk { get; set; }

    public string RmthlabName { get; set; }

    public DateTime? RmthsentDate { get; set; }

    public DateTime? RmthexpectedDate { get; set; }

    public string RmthrequestedBy { get; set; }

    public DateTime? RmthreceivedDate { get; set; }

    public string Rmthreference { get; set; }

    public string RmthanalyzerName { get; set; }

    public string Rmthcomment { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
