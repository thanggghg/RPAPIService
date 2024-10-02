using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteRfqlog
{
    public int Id { get; set; }

    public int QuoteHeaderNoFk { get; set; }

    public string QhcustomerNoFk { get; set; }

    public int? QhsoheaderNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int QhstatusNoFk { get; set; }

    public string SaleRep { get; set; }

    public string Csrep { get; set; }

    public string Rfqno { get; set; }

    public string ProductDesc { get; set; }

    public string Rfqrequest { get; set; }

    public string Formulator { get; set; }

    public string Rfqstatus { get; set; }

    public string QfmlCode { get; set; }

    public decimal? QfmlCodeVer { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int? ProductTypeFk { get; set; }

    public string Qhnotes { get; set; }
}
