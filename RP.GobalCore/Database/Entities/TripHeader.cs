using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class TripHeader
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public DateTime StartTime { get; set; }

    public string StartAddress { get; set; }

    public DateTime? EndTime { get; set; }

    public string EndAddress { get; set; }

    public decimal? EstDistance { get; set; }

    public decimal? ActDistance { get; set; }

    public decimal? EstDuration { get; set; }

    public decimal? ActDuration { get; set; }

    public string Notes { get; set; }

    public DateTime? ApprovedDt { get; set; }

    public string ApprovedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
