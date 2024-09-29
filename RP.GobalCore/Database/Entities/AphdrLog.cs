using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class AphdrLog
{
    public int AphdrLogPk { get; set; }

    public int ApheaderNoPk { get; set; }

    public int AphvendorNoFk { get; set; }

    public string AphcustomerNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int AphstatusNoFk { get; set; }

    public int? AphbatchNoFk { get; set; }

    public string Aphponumber { get; set; }

    public string ApholdPonumber { get; set; }

    public int AphapbillToNoFk { get; set; }

    public int AphapshipToNoFk { get; set; }

    public string AphscacCode { get; set; }

    public string AphscacName { get; set; }

    public int? AphpaymentCodeTypeNoFk { get; set; }

    public double? AphfreightCharge { get; set; }

    public int? Aphterms { get; set; }

    public string Aphfob { get; set; }

    public double Aphpoqty { get; set; }

    public bool? Aphpomanual { get; set; }

    public bool AphnonManfacturingPo { get; set; }

    public string AphorderedBy { get; set; }

    public string AphrequestedBy { get; set; }

    public string AphenteredBy { get; set; }

    public string Aphordered4Dept { get; set; }

    public double? AphtaxRate { get; set; }

    public decimal AphtaxAmount { get; set; }

    public decimal Aphpoamount { get; set; }

    public DateTime Aphpodate { get; set; }

    public string AphorderDesc { get; set; }

    public string Aphnotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool? AphbanketPo { get; set; }

    public DateTime? AphconfirmDt { get; set; }

    public string AphconfirmBy { get; set; }

    public DateTime? AphapprovedDt { get; set; }

    public string AphapprovedBy { get; set; }

    public string AphrejectedBy { get; set; }
}
