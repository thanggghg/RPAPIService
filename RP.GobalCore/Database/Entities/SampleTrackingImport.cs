using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTrackingImport
{
    public DateTime? DateQcreceived { get; set; }

    public DateTime? DateQasampled { get; set; }

    public string ItemDescription { get; set; }

    public string Item { get; set; }

    public string Lot { get; set; }

    public string Lab { get; set; }

    public string TestingRequired { get; set; }

    public DateTime? DateSent { get; set; }

    public DateTime? DateResultsExpected { get; set; }

    public DateTime? DateResultsReceived { get; set; }

    public string Reference { get; set; }

    public DateTime? SampleReturnDate { get; set; }

    public string BotanicalName { get; set; }

    public string Vendor { get; set; }

    public string ExtractSolvent { get; set; }

    public string PlantParts { get; set; }

    public string Comments { get; set; }

    public string Status { get; set; }
}
