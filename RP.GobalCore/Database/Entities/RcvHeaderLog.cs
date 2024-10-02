using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvHeaderLog
{
    public int RcvHeaderNoPk { get; set; }

    public bool RcvHnonManReceived { get; set; }

    public int? RcvHbatchNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RcvHstatusNoFk { get; set; }

    public int RcvHcustomerNoFk { get; set; }

    public int RcvHitemKeyNoFk { get; set; }

    public string RcvHitemNumber { get; set; }

    public string RcvhitemDesc { get; set; }

    public int RcvHproductClassNoFk { get; set; }

    public int? RcvHproductTypeNoFk { get; set; }

    public int RcvHvendorNoFk { get; set; }

    public double RcvHqtyExpected { get; set; }

    public DateTime? RcvHdateExpected { get; set; }

    public double RcvHqtyReceived { get; set; }

    public DateTime? RcvHdateReceived { get; set; }

    public double RcvHqtyQai { get; set; }

    public DateTime? RcvHdateQai { get; set; }

    public int RcvHaptransNoFk { get; set; }

    public int? RcvHapbatchNoFk { get; set; }

    public string RcvHapponumber { get; set; }

    public int RcvHapheaderNoFk { get; set; }

    public bool RcvHisFullReceived { get; set; }

    public string RcvHnotes { get; set; }

    public string Remarks { get; set; }

    public double? RcvHreturnedQty { get; set; }

    public DateTime? RcvHreturnedDate { get; set; }

    public string RcvHreturnedNotes { get; set; }

    public string RcvHreturnedBy { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
