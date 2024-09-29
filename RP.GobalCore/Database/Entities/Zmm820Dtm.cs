using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm820Dtm
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string TraceId { get; set; }

    public int EntNo { get; set; }

    public int RecId { get; set; }

    public string Dtm01DateQ { get; set; }

    public DateTime? Dtm02Date { get; set; }

    public DateTime? CreatedDt { get; set; }
}
