using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteDetail
{
    public int QuoteDetailNoPk { get; set; }

    public int QdheaderNoFk { get; set; }

    public int QdstatusNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? QditemMasterNoFk { get; set; }

    public string QdimcustomerNoFk { get; set; }

    public string QdimitemId { get; set; }

    public int Qdimpack { get; set; }

    public string QdcustomerItemNumber { get; set; }

    public string QdformulaNumber { get; set; }

    public string QditemDescription { get; set; }

    public int? QdorderedUom { get; set; }

    public int QdcustomerOrderQty { get; set; }

    public int QdproductionQty { get; set; }

    public double QdcostPerThousand { get; set; }

    public double QdpricePerThousand { get; set; }

    public double QdextCost { get; set; }

    public double QdextPrice { get; set; }

    public DateTime? QddeliveryDate { get; set; }

    public string Qdnotes { get; set; }

    public double? QdfillWtPerUnit { get; set; }

    public decimal? QditemMasterVer { get; set; }

    public int? QdrnDfmlNoFk { get; set; }

    public string QdrnDfmlCode { get; set; }

    public decimal? QdrnDfmlCodeVer { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string RnDverifyBy { get; set; }

    public DateTime? RnDverifyDt { get; set; }

    public int? RnDverifyStatus { get; set; }

    public string QaverifyBy { get; set; }

    public DateTime? QaverifyDt { get; set; }

    public int? QaverifyStatus { get; set; }

    public decimal? QdimspecVersion { get; set; }

    public int? QdimspecNoFk { get; set; }
}
