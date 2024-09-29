using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FormRequest
{
    public string Id { get; set; }

    public string TemplateId { get; set; }

    public int FormStatusNoFk { get; set; }

    public string FmlCode { get; set; }

    public string FmlVersion { get; set; }

    public int? QuoteNumber { get; set; }

    public int? Sonumber { get; set; }

    public string CustomerName { get; set; }

    public string Imcode { get; set; }

    public string Imversion { get; set; }

    public string Imdescription { get; set; }

    public string Brlot { get; set; }

    public int? LoadNumber { get; set; }

    public string Rmcode { get; set; }

    public string WhsLot { get; set; }

    public string Ponumber { get; set; }

    public int? VendorNoFk { get; set; }

    public string VendorName { get; set; }

    public int? PkgBatch { get; set; }

    public int? Rtvkey { get; set; }

    public int? MfrNoFk { get; set; }

    public string MfrName { get; set; }

    public string UserList { get; set; }

    public string UserModified { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string ItemDocDirectory { get; set; }
}
