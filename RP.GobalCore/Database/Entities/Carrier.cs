using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Carrier
{
    public string CarrierCode { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Scac { get; set; }

    public string CarrierName { get; set; }

    public string CarrierPrefix { get; set; }

    public string CarrierTypeEdi { get; set; }

    public string CarrierProNoStart { get; set; }

    public string CarrierProNoEnd { get; set; }

    public int CarrierProNoWaterMark { get; set; }

    public string CarrierProCurrent { get; set; }

    public bool CarrierGeneratePro { get; set; }

    public bool CarrierRequireProNumber { get; set; }

    public DateTime? CarrierStatusDt { get; set; }

    public DateTime CarrierCreatedDt { get; set; }

    public string CarrierCreatedBy { get; set; }

    public DateTime CarrierLastUpdDt { get; set; }

    public string CarrierLastUpdBy { get; set; }

    public string CarrierAddress1 { get; set; }

    public string CarrierAddress2 { get; set; }

    public string CarrierZipCode { get; set; }

    public string CarrierPostalCode { get; set; }

    public string CarrierCity { get; set; }

    public string CarrierState { get; set; }

    public string CarrierCountry { get; set; }

    public string CarrierPhone1 { get; set; }

    public string CarrierPhone2 { get; set; }

    public string CarrierFax1 { get; set; }

    public string CarrierFax2 { get; set; }

    public string CarrierGeneralContact { get; set; }

    public string CarrierContactPhone { get; set; }

    public string CarrierContactEmail { get; set; }

    public string CarrierCorporateEmail { get; set; }

    public string CarrierWebAddress { get; set; }
}
