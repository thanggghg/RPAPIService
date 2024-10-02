using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Company
{
    public string CompanyIdPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Gln { get; set; }

    public string CompanyGs1code { get; set; }

    public string CompanyName { get; set; }

    public string CompanyAddr1 { get; set; }

    public string CompanyAddr2 { get; set; }

    public string CompanyCity { get; set; }

    public string CompanyState { get; set; }

    public string CompanyZipCode { get; set; }

    public string CompanyPostalCode { get; set; }

    public string CompanyCountry { get; set; }

    public string CompanyPhone1 { get; set; }

    public string CompanyPhone2 { get; set; }

    public string CompanyFax1 { get; set; }

    public string CompanyFax2 { get; set; }

    public string CompanyContact { get; set; }

    public string CompanyEmail { get; set; }

    public string CompanyContactEmail { get; set; }

    public string CompanyContactPhone { get; set; }

    public string CompanyContactPhoneExt { get; set; }

    public string CompanyUrl { get; set; }

    public string CompanyBillName { get; set; }

    public string CompanyBillAttn { get; set; }

    public string CompanyBillAddr1 { get; set; }

    public string CompanyBilladdr2 { get; set; }

    public string CompanyBillCity { get; set; }

    public string CompanyBillState { get; set; }

    public string CompanyBillZipCode { get; set; }

    public string CompanyBillPostalCode { get; set; }

    public string CompanyBillCountry { get; set; }

    public string CompanyBillPhone1 { get; set; }

    public string CompanyBillPhonex1 { get; set; }

    public string CompanyBillPhone2 { get; set; }

    public string CompanyBillPhonex2 { get; set; }

    public string CompanyBillFax1 { get; set; }

    public string CompanyBillFax2 { get; set; }

    public string CompanyBillEmail { get; set; }

    public string CompanyWeeklyPed { get; set; }

    public string CompanyMonthlyPed { get; set; }

    public int? CompanyWhsNoFk { get; set; }

    public string CompanyRcvName { get; set; }

    public string CompanyRcvAttention { get; set; }

    public string CompanyRcvAddr1 { get; set; }

    public string CompanyRcvAddr2 { get; set; }

    public string CompanyRcvZipCode { get; set; }

    public string CompanyRcvPostalCode { get; set; }

    public string CompanyRcvCity { get; set; }

    public string CompanyRcvState { get; set; }

    public string CompanyRcvCountry { get; set; }

    public string CompanyRcvContactEmail { get; set; }

    public string CompanyRcvPhone1 { get; set; }

    public string CompanyRcvPhone1Ext { get; set; }

    public string CompanyRcvPhone2 { get; set; }

    public string CompanyRcvPhone2Ext { get; set; }

    public string CompanyRcvFax1 { get; set; }

    public string CompanyRcvFax2 { get; set; }

    public string CompanyRcvScac { get; set; }

    public string CompanySpecialShippingInstruction { get; set; }

    public string CreatedBy { get; set; }

    public string CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public string LastUpdDt { get; set; }
}
