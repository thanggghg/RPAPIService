using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812Hdr
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int GroupId { get; set; }

    public DateTime? Bcd01ClaimDate { get; set; }

    public string Bcd02DocNumber { get; set; }

    public string Bcd03TransactionCd { get; set; }

    public double? Bcd04Amount { get; set; }

    public string Bcd05CrDebFlag { get; set; }

    public DateTime? Bcd06InvDate { get; set; }

    public string Bcd07InvNumber { get; set; }

    public DateTime? Bcd09Podate { get; set; }

    public string Bcd10Po { get; set; }

    public string Bcd11PurposeCd { get; set; }

    public string Bcd12TransactionTypeCd { get; set; }

    public string Bcd13RefIdq { get; set; }

    public string Bcd14RefId { get; set; }

    public string Cur02CurrCd { get; set; }

    public string Fob01MethodOfPayment { get; set; }

    public DateTime? CreatedDt { get; set; }
}
