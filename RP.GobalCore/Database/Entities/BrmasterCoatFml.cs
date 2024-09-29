using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class BrmasterCoatFml
{
    public int BrmasterCoatFormulaPk { get; set; }

    public int BrmcfmasterHeaderFk { get; set; }

    public int BrmcforderSort { get; set; }

    public string BrmcfitemNum { get; set; }

    public int? BrmcfitemFk { get; set; }

    public string BrmcfitemCode { get; set; }

    public string BrmcfitemDesc { get; set; }

    public decimal? BrmcfunitWt { get; set; }

    public int RecStatusNoFk { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }

    public int? BrmcoatFmlHdrFk { get; set; }

    public virtual BrmasterHeader BrmcfmasterHeaderFkNavigation { get; set; }
}
