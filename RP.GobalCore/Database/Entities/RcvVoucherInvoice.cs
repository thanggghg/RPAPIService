using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RcvVoucherInvoice
{
    public int RvinvoiceNoPk { get; set; }

    public int RvhdrFk { get; set; }

    public int RvdetailFk { get; set; }

    public string RvcheckNum { get; set; }

    public string VendorInvoice { get; set; }

    public DateTime? VendorInvoiceDt { get; set; }

    public DateTime? PaidDt { get; set; }

    public string PaidBy { get; set; }

    public decimal? Apqty { get; set; }

    public decimal? ApunitCost { get; set; }

    public byte[] Picture { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public virtual RcvVoucherDetail RvdetailFkNavigation { get; set; }

    public virtual RcvVoucherHeader RvhdrFkNavigation { get; set; }
}
