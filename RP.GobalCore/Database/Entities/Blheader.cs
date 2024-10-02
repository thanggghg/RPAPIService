using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Blheader
{
    public int BlheaderNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int BlhstatusNoFk { get; set; }

    public int BlhsoheaderNoFk { get; set; }

    public int Blhsoqty { get; set; }

    public string BlhcustPo { get; set; }

    public int BlhcustNoFk { get; set; }

    public string BlhscacCode { get; set; }

    public string BlhscacName { get; set; }

    public string Blhpro { get; set; }

    public string BlhpayCode { get; set; }

    public int BlhbilltoNoFk { get; set; }

    public int BlhshiptoNoFk { get; set; }

    public int BlhtotalQty { get; set; }

    public DateTime? BlhallocatedDate { get; set; }

    public string BlhallocatedBy { get; set; }

    public DateTime? BlhprintedDate { get; set; }

    public string BlhprintedBy { get; set; }

    public DateTime? BlhrePrintedDate { get; set; }

    public string BlhrePrintedBy { get; set; }

    public DateTime? BlhvoidedDate { get; set; }

    public string BlhvoidedBy { get; set; }

    public DateTime? BlhshipDate { get; set; }

    public DateTime? BlhwhshipDate { get; set; }

    public string BlhshipBy { get; set; }

    public bool BlhisShipAll { get; set; }

    public string BlhcustNewPonum { get; set; }

    public string BlhwareHouseIns { get; set; }

    public string BlhcustServInstr { get; set; }

    public string BlhbtstrName { get; set; }

    public string BlhbtstrAddress1 { get; set; }

    public string BlhbtstrAddress2 { get; set; }

    public string BlhbtstrCity { get; set; }

    public string BlhbtstrState { get; set; }

    public string BlhbtstrZip { get; set; }

    public string BlhbtstrPostal { get; set; }

    public string BlhbtstrCountry { get; set; }

    public string BlhbtstrAttn { get; set; }

    public string BlhbtstrPhone1 { get; set; }

    public string BlhbtstrPhoneExt { get; set; }

    public string BlhbtstrPhone2 { get; set; }

    public string BlhbtstrFax1 { get; set; }

    public string BlhbtstrFax2 { get; set; }

    public string BlhbtstrEmail { get; set; }

    public string BlhststrName { get; set; }

    public string BlhststrAddress1 { get; set; }

    public string BlhststrAddress2 { get; set; }

    public string BlhststrCity { get; set; }

    public string BlhststrState { get; set; }

    public string BlhststrZip { get; set; }

    public string BlhststrPostal { get; set; }

    public string BlhststrCountry { get; set; }

    public string BlhststrAttn { get; set; }

    public string BlhststrPhone1 { get; set; }

    public string BlhststrPhoneExt { get; set; }

    public string BlhststrPhone2 { get; set; }

    public string BlhststrFax1 { get; set; }

    public string BlhststrFax2 { get; set; }

    public string BlhststrEmail { get; set; }

    public bool? Blhstfob { get; set; }

    public bool? Blhsffob { get; set; }

    public string Remarks { get; set; }

    public string BlhspcInstr { get; set; }

    public string BlhtrailerNo { get; set; }

    public string BlhsealNo { get; set; }

    public int? BlhchargeTerms { get; set; }

    public double? Blhcodamount { get; set; }

    public int? Blhcodterms { get; set; }

    public bool? BlhcustCheck { get; set; }

    public int? BlhloadedBy { get; set; }

    public int? BlhcountedBy { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string BlhbtediwhsId { get; set; }

    public string BlhstediwhsId { get; set; }

    public string BlhpickupLoc { get; set; }

    public string Blhconversation { get; set; }
}
