using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerCarrier
{
    public int CustomerCarrierNoPk { get; set; }

    public int CccustomerNoFk { get; set; }

    public string CcscacnoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CcaccountNo { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
