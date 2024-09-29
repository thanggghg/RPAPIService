using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvVoucherHeader
{
    public int RvheaderNoPk { get; set; }

    public int RvvendorNoFk { get; set; }

    public string Rvponum { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RvvoucherId { get; set; }

    public string CarrierName { get; set; }

    public string Term { get; set; }

    public string Department { get; set; }

    public bool IsDebit { get; set; }

    public string PoorderBy { get; set; }

    public DateTime? PaidDt { get; set; }

    public string PaidBy { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual ICollection<RcvVoucherDetail> RcvVoucherDetails { get; set; } = new List<RcvVoucherDetail>();

    public virtual ICollection<RcvVoucherInvoice> RcvVoucherInvoices { get; set; } = new List<RcvVoucherInvoice>();

    public virtual Vendor RvvendorNoFkNavigation { get; set; }
}
