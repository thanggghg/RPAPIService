using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class WeighUpSchedule
{
    public int WuschedNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Wuslot { get; set; }

    public int WusbatchHeaderNoFk { get; set; }

    public DateTime? StartWuschedDate { get; set; }

    public DateTime? EndWuschedDate { get; set; }

    public string Comment { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public string WusloadNumber { get; set; }

    public int? WusroomNumber { get; set; }

    public int? Wuspriority { get; set; }

    public DateTime? ShipWuschedDate { get; set; }

    public DateTime? RmreadyDate { get; set; }

    public int? WustotalPallets { get; set; }

    public string RmreadyStampedBy { get; set; }

    public string StartWusstampedBy { get; set; }

    public string EndWusstampedBy { get; set; }

    public string ShipWusstampedBy { get; set; }

    public string Remark { get; set; }

    public string Wusduration { get; set; }

    public DateTime? InWuschedDate { get; set; }

    public string InWusstampedBy { get; set; }

    public bool? Wuscheduled { get; set; }

    public bool? Wurmready { get; set; }

    public DateTime? WubatchSentOutDate { get; set; }

    public string WubatchSentOutBy { get; set; }

    public DateTime? WubatchReceivedDate { get; set; }

    public string WubatchReceivedBy { get; set; }
}
