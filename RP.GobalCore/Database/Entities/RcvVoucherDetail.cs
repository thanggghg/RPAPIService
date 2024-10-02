using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvVoucherDetail
{
    public int RvdetailNoPk { get; set; }

    public int RvheaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string RvitemCode { get; set; }

    public string RvitemDesc { get; set; }

    public decimal RvorderQty { get; set; }

    public int Rvboxes { get; set; }

    public decimal RvqtyPerBox { get; set; }

    public decimal RvtotalQty { get; set; }

    public decimal RvunitPrice { get; set; }

    public string RvvendorLot { get; set; }

    public string RvwhsLot { get; set; }

    public string Remark { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual ICollection<RcvVoucherInvoice> RcvVoucherInvoices { get; set; } = new List<RcvVoucherInvoice>();

    public virtual RcvVoucherHeader RvheaderNoFkNavigation { get; set; }
}
