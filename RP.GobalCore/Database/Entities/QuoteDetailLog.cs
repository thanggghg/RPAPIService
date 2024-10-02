using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class QuoteDetailLog
{
    public int QuoteDetailLogNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int? QdlsoheaderNoFk { get; set; }

    public int? QdlquoteHeaderNoFk { get; set; }

    public string QdluserIdFk { get; set; }

    public DateTime Qdldate { get; set; }

    public string Qdlnotes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
