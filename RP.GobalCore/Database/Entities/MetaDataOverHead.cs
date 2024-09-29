using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class MetaDataOverHead
{
    public int MdoverheadNoPk { get; set; }

    public string Mdohname { get; set; }

    public bool MdohdirectOverhead { get; set; }

    public double MdohpercentOfBulkCost { get; set; }

    public int RecStatusNoFk { get; set; }

    public string MdohorderEntry { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public int OhtypeFk { get; set; }

    public int OhcatergoryFk { get; set; }
}
