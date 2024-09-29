using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteHeader
{
    public int QuoteHeaderNoPk { get; set; }

    public string QhcustomerNoFk { get; set; }

    public int? QhsoheaderNoFk { get; set; }

    public bool QhcostStructureModified { get; set; }

    public string QhsortedKey { get; set; }

    public int RecStatusNoFk { get; set; }

    public int QhstatusNoFk { get; set; }

    public DateTime? QhquoteDate { get; set; }

    public DateTime QhexpirationDate { get; set; }

    public string QhattnTitle { get; set; }

    public string QhattnName { get; set; }

    public string QhattnPhone { get; set; }

    public string QhattnFax { get; set; }

    public string QhattnEmail { get; set; }

    public string QhpreparedBy { get; set; }

    public string QhapprovedBy { get; set; }

    public DateTime? QhapprovedDate { get; set; }

    public string QhvoidedBy { get; set; }

    public DateTime? QhvoidedDate { get; set; }

    public string Qhremarks { get; set; }

    public bool? QhisItemMaster { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string SaleRep { get; set; }

    public string Csrep { get; set; }

    public string Rfqno { get; set; }

    public string ProductDesc { get; set; }

    public string Formulator { get; set; }

    public string Rfqstatus { get; set; }

    public string Qhnotes { get; set; }

    public int? ProductTypeFk { get; set; }

    public string Rfqrequest { get; set; }

    public string LeadCodeFk { get; set; }

    public string ExistsFmlNver { get; set; }

    public string BatchSize { get; set; }

    public string Flexibility { get; set; }

    public string NeedMatching { get; set; }

    public bool PreviouslyMfg { get; set; }

    public string DestinationCountry { get; set; }

    public string SizeShape { get; set; }

    public string ColorType { get; set; }

    public string Color { get; set; }

    public string Flavor { get; set; }

    public string GelType { get; set; }

    public string Coating { get; set; }

    public bool Printing { get; set; }

    public bool VendorSpec { get; set; }

    public bool NonGmo { get; set; }

    public bool Vegan { get; set; }

    public bool Organic { get; set; }

    public bool CustSupply { get; set; }

    public bool HalalCert { get; set; }

    public bool StabilityAdditionTest { get; set; }

    public bool Nsfsport { get; set; }

    public bool UseDefault { get; set; }

    public bool RestrictExcipient { get; set; }

    public bool KosherCert { get; set; }

    public bool GlutenFree { get; set; }

    public bool MiscAllergen { get; set; }

    public bool Others { get; set; }

    public bool HasSample { get; set; }

    public bool HasLabel { get; set; }

    public bool HasFormula { get; set; }

    public bool HasFlavorProfile { get; set; }

    public string ListCert { get; set; }

    public string TypeOfChange { get; set; }

    public string OldInfo { get; set; }

    public string NewInfo { get; set; }

    public string Notes { get; set; }

    public string ProjectedServingSize { get; set; }

    public decimal? EstAnnualVolume { get; set; }

    public string CustPonum { get; set; }

    public DateTime? CustPorecvDt { get; set; }

    public bool? RfqreadyToSign { get; set; }
}
