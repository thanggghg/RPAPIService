using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812Per
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int ParentGroupId { get; set; }

    public string Per01ContactFcd { get; set; }

    public string Per02Name { get; set; }

    public string Per03CommNumberQ { get; set; }

    public string Per04CommNumber { get; set; }

    public DateTime? CreatedDt { get; set; }
}
