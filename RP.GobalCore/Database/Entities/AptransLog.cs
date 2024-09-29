using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class AptransLog
{
    public int AptransLogPk { get; set; }

    public int AptransNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? AptrminvTransNoPk { get; set; }

    public int? AptapheaderNoFk { get; set; }

    public string Aptapponumber { get; set; }

    public DateTime AptdeliveryDate { get; set; }

    public DateTime? AptreceivedDate { get; set; }

    public int AptstatusNoFk { get; set; }

    public int? AptbatchNoFk { get; set; }

    public int? AptvendorNoFk { get; set; }

    public int? AptrawMaterialNoFk { get; set; }

    public string AptrmitemNumber { get; set; }

    public string AptrmassignedDescr { get; set; }

    public string AptassignedUom { get; set; }

    public int AptcustomerNoFk { get; set; }

    public string AptrefNumber { get; set; }

    public int? AptcostCenterNoFk { get; set; }

    public string AptcostAcctNoFk { get; set; }

    public double? Aptbomqty { get; set; }

    public double ApttransQty { get; set; }

    public double? ApttransQtyReceived { get; set; }

    public double ApttransUnitPrice { get; set; }

    public double ApttransTax { get; set; }

    public double ApttransAmt { get; set; }

    public DateTime ApttransDate { get; set; }

    public string Aptnotes { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string AptitemNote { get; set; }

    public decimal? AptmiscItemCost { get; set; }

    public decimal? AptunitActualPrice { get; set; }

    public DateTime? AptconfirmDt { get; set; }

    public string AptconfirmBy { get; set; }

    public DateTime? AptapprovedDt { get; set; }

    public string AptapprovedBy { get; set; }

    public decimal? AptapprovedUnitCost { get; set; }

    public decimal? AptblanketQty { get; set; }

    public string ApttrackingNumber { get; set; }

    public DateTime? ApttrackingEta { get; set; }
}
