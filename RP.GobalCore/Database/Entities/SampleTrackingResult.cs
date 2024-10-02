using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingResult
{
    public int RmtrnoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmtFk { get; set; }

    public bool? IsFg { get; set; }

    public string Rmtrlab { get; set; }

    public string Rmtranalyst { get; set; }

    public string RmtrtestsReqired { get; set; }

    public DateTime? Rmtrreceived { get; set; }

    public DateTime? RmtrdtSentToLab { get; set; }

    public DateTime? RmtrdtExpected { get; set; }

    public DateTime? RmtrdtResultsReported { get; set; }

    public string Rmtrsubtest { get; set; }

    public string Rmtrresults { get; set; }

    public string Rmtrunit { get; set; }

    public string Rmtrreference { get; set; }

    public DateTime? RmtrdtSampleReturned { get; set; }

    public string RmtrbotName { get; set; }

    public string RmtrextractSolvent { get; set; }

    public string RmtrplantParts { get; set; }

    public string Rmtrcomment { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public bool IsBulkTest { get; set; }

    public bool IsPkgTest { get; set; }

    public bool IsMixTest { get; set; }

    public DateTime? StartTestDt { get; set; }

    public string VerifyBy { get; set; }

    public string Rmtrmethod { get; set; }
}
