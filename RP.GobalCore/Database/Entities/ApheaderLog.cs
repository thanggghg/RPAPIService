using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ApheaderLog
{
    public int ApheaderLogNoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Aphlponumber { get; set; }

    public string AphluserIdFk { get; set; }

    public DateTime Aphldate { get; set; }

    public string Aphlnotes { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
