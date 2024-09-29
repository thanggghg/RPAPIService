using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class CustomerLog
{
    public string CustomerNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? CustomerBusTypeFk { get; set; }

    public string CustomerSortedKey { get; set; }

    public string CustomerName { get; set; }

    public string CustomerEdiId { get; set; }

    public string CustomerAccountQb { get; set; }

    public string CustomerNameQb { get; set; }

    public string CustomerAddr1 { get; set; }

    public string CustomerAddr2 { get; set; }

    public string CustomerCity { get; set; }

    public string CustomerState { get; set; }

    public string CustomerZipCode { get; set; }

    public string CustomerPostalCode { get; set; }

    public string CustomerCountry { get; set; }

    public string CustomerPhone1 { get; set; }

    public string CustomerPhone2 { get; set; }

    public string CustomerFax1 { get; set; }

    public string CustomerFax2 { get; set; }

    public string CustomerContact { get; set; }

    public string CustomerEmail { get; set; }

    public string CustomerContactEmail { get; set; }

    public string CustomerContactPhone { get; set; }

    public string CustomerUrl { get; set; }

    public string CustomerFedTaxId { get; set; }

    public string CustomerBillName { get; set; }

    public string CustomerBillAttn { get; set; }

    public string CustomerBillAddr1 { get; set; }

    public string CustomerBilladdr2 { get; set; }

    public string CustomerBillCity { get; set; }

    public string CustomerBillState { get; set; }

    public string CustomerBillZipCode { get; set; }

    public string CustomerBillPostalCode { get; set; }

    public string CustomerBillCountry { get; set; }

    public string CustomerBillPhone1 { get; set; }

    public string CustomerBillPhoneExt { get; set; }

    public string CustomerBillPhone2 { get; set; }

    public string CustomerBillFax1 { get; set; }

    public string CustomerBillFax2 { get; set; }

    public string CustomerBillEmail { get; set; }

    public int? CustomerTerms { get; set; }

    public decimal CustomerCreditLimit { get; set; }

    public string CustomerWeeklyPed { get; set; }

    public string CustomerMonthlyPed { get; set; }

    public string CustomerShipToName { get; set; }

    public string CustomerShipToAttention { get; set; }

    public string CustomerShipToAddress1 { get; set; }

    public string CustomerShipToAddress2 { get; set; }

    public string CustomerShipToZipCode { get; set; }

    public string CustomerShipToPostalCode { get; set; }

    public string CustomerShipToCity { get; set; }

    public string CustomerShipToState { get; set; }

    public string CustomerShipToCountry { get; set; }

    public string CustomerShipToEmail { get; set; }

    public string CustomerShipToPhone1 { get; set; }

    public string CustomerShipToPhone2 { get; set; }

    public string CustomerShipToPhoneExt { get; set; }

    public string CustomerShipToFax1 { get; set; }

    public string CustomerShipToFax2 { get; set; }

    public string CustomerCarrierAcctNumber { get; set; }

    public string CustomerSpecialShippingInstruction { get; set; }

    public string CustomerShipToScac { get; set; }

    public int CustomerCartonCounter { get; set; }

    public int CustomerExtensionDigit { get; set; }

    public bool CustomerResetCartonCounter { get; set; }

    public string CustomerManufactureNumber { get; set; }

    public string WebName { get; set; }

    public string WebPassword { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string SalesRep { get; set; }

    public string CustEdiDuns { get; set; }

    public string CustEdiVendorId { get; set; }

    public string Phone1Ext { get; set; }

    public string Phone2Ext { get; set; }

    public string Csrep { get; set; }

    public bool? ShipmentOnHold { get; set; }

    public string CustomerSource { get; set; }

    public string ProdLabel { get; set; }

    public bool? InActive { get; set; }

    public string SalesRep2 { get; set; }

    public string Akacustomer { get; set; }

    public string Remarks { get; set; }

    public string LeadCodeFk { get; set; }
}
