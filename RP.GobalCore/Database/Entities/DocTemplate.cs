using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class DocTemplate
{
    public int DocTemplateId { get; set; }

    public string DocCategory { get; set; }

    public string DocName { get; set; }

    public string DocCode { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
