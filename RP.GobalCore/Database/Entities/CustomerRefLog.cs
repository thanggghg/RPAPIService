using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerRefLog
{
    public int CustRefNoPk { get; set; }

    public int CustRefCustomerNoFk { get; set; }

    public int CustRefTypeNoFk { get; set; }

    public string CustRefName { get; set; }

    public string CustRefAcct { get; set; }

    public string CustRefAddr { get; set; }

    public string CustRefPhone { get; set; }

    public string CustRefFax { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Remarks { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
