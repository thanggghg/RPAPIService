using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm810Hdr
{
    public int InvoiceId { get; set; }

    public int? Processing { get; set; }

    public DateTime? HdrinvoiceSent { get; set; }

    public string Partner { get; set; }

    public DateTime? HdrconfirmationReceived { get; set; }

    public DateTime? HdrinvoiceDate { get; set; }

    public string HdrinvoiceNumber { get; set; }

    public DateTime? HdrpoDate { get; set; }

    public string HdrpoNumber { get; set; }

    public string HdrinternalVendorNumber { get; set; }

    public string HdrdepartmentNumber { get; set; }

    public string HdrmerchandiseTypeCode { get; set; }

    public string HdrsupplierName { get; set; }

    public string HdrsupplierCdq { get; set; }

    public string HdrsupplierCd { get; set; }

    public string HdrsupplierAddr1 { get; set; }

    public string HdrsupplierAddr2 { get; set; }

    public string HdrsupplierAddr3 { get; set; }

    public string HdrsupplierAddr4 { get; set; }

    public string HdrsupplierCity { get; set; }

    public string HdrsupplierState { get; set; }

    public string HdrsupplierZip { get; set; }

    public string HdrsupplierCountry { get; set; }

    public string HdrshipToName { get; set; }

    public string HdrshipToGln { get; set; }

    public string HdrshipToAddr1 { get; set; }

    public string HdrshipToAddr2 { get; set; }

    public string HdrshipToAddr3 { get; set; }

    public string HdrshipToAddr4 { get; set; }

    public string HdrshipToCity { get; set; }

    public string HdrshipToState { get; set; }

    public string HdrshipToZip { get; set; }

    public string HdrshipToCountry { get; set; }

    public string HdrtermsTypeCd { get; set; }

    public string HdrtermsBasisDateCd { get; set; }

    public double? HdrtermsDiscountPct { get; set; }

    public int? HdrtermsDiscountDaysDue { get; set; }

    public int? HdrtermNetDays { get; set; }

    public double? HdrtermsDiscountAmount { get; set; }

    public string HdrtermsDescription { get; set; }

    public DateTime? HdrshippedDate { get; set; }

    public DateTime? HdreffectiveDate { get; set; }

    public string HdrshipmentMethodOfPayment { get; set; }

    public double? HdrinvoiceTotal { get; set; }

    public string HdrcarrierAlphaCode { get; set; }

    public string HdrcarrierProCode { get; set; }

    public string Hdrrouting { get; set; }

    public string HdrreferenceIdq { get; set; }

    public string HdrreferenceId { get; set; }

    public int? HdrsacId { get; set; }

    public double? HdrnumberOfUnits { get; set; }

    public string HdrnumberUnitCode { get; set; }

    public double? Hdrweight { get; set; }

    public string HdrweightUnitCode { get; set; }

    public int? HdrnumberOfLineItems { get; set; }

    public int? Wm810soheader { get; set; }

    public DateTime? CreatedDt { get; set; }
}
