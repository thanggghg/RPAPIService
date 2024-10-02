using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Vendor
{
    public int VendorNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string VendorSortedKey { get; set; }

    public string VendorName { get; set; }

    public string VendorCode { get; set; }

    public string VendorAddr1 { get; set; }

    public string VendorAddr2 { get; set; }

    public string VendorCity { get; set; }

    public string VendorState { get; set; }

    public string VendorZipCode { get; set; }

    public string VendorPostalCode { get; set; }

    public string VendorCountry { get; set; }

    public string VendorPhone1 { get; set; }

    public string VendorPhone2 { get; set; }

    public string VendorFax1 { get; set; }

    public string VendorFax2 { get; set; }

    public string VendorContact { get; set; }

    public string VendorEmail { get; set; }

    public string VendorContactEmail { get; set; }

    public string VendorContactPhone { get; set; }

    public string VendorContactExt { get; set; }

    public string VendorUrl { get; set; }

    public string VendorBillName { get; set; }

    public string VendorBillAttn { get; set; }

    public string VendorBillAddr1 { get; set; }

    public string VendorBilladdr2 { get; set; }

    public string VendorBillCity { get; set; }

    public string VendorBillState { get; set; }

    public string VendorBillZipCode { get; set; }

    public string VendorBillPostalCode { get; set; }

    public string VendorBillCountry { get; set; }

    public string VendorBillPhone1 { get; set; }

    public string VendorBillPhone2 { get; set; }

    public string VendorBillFax1 { get; set; }

    public string VendorBillFax2 { get; set; }

    public string VendorBillEmail { get; set; }

    public int VendorProductLeadTime { get; set; }

    public int VendorTerms { get; set; }

    public int? VendorPaymentCodeTypeNoFk { get; set; }

    public string VendorScacCode { get; set; }

    public string VendorScacName { get; set; }

    public string VendorFob { get; set; }

    public string VendorShipToName { get; set; }

    public string VendorShipToAttention { get; set; }

    public string VendorShipToAddress1 { get; set; }

    public string VendorShipToAddress2 { get; set; }

    public string VendorShipToZipCode { get; set; }

    public string VendorShipToPostalCode { get; set; }

    public string VendorShipToCity { get; set; }

    public string VendorShipToState { get; set; }

    public string VendorShipToCountry { get; set; }

    public string VendorShipToEmail { get; set; }

    public string VendorShipToPhone1 { get; set; }

    public string VendorShipToPhone2 { get; set; }

    public string VendorShipToFax1 { get; set; }

    public string VendorShipToFax2 { get; set; }

    public string VendorCarrierAcctNumber { get; set; }

    public string VendorSpecialShippingInstruction { get; set; }

    public string VendorShipToScac { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public string CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public string LastUpdDt { get; set; }

    public string OwnerName { get; set; }

    public string OwnerEmailAddr { get; set; }

    public string QacontactName { get; set; }

    public string QaemailAddr { get; set; }

    public string QccontactName { get; set; }

    public string QcemailAddr { get; set; }

    public bool? IsForeign { get; set; }

    public virtual ICollection<RawMaterialByVendor> RawMaterialByVendors { get; set; } = new List<RawMaterialByVendor>();

    public virtual ICollection<RcvVoucherHeader> RcvVoucherHeaders { get; set; } = new List<RcvVoucherHeader>();
}
