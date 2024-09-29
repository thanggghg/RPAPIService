using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm812N1
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public string DocNumber { get; set; }

    public int GroupId { get; set; }

    public int ParentGroupId { get; set; }

    public string N101EntityIdc { get; set; }

    public string N102Name { get; set; }

    public string N103IdentificationCdq { get; set; }

    public string N104IdentificationCd { get; set; }

    public string N3011Addr { get; set; }

    public string N3021Addr { get; set; }

    public string N3012Addr { get; set; }

    public string N3022Addr { get; set; }

    public string N401City { get; set; }

    public string N402State { get; set; }

    public string N403Zip { get; set; }

    public string N404Country { get; set; }

    public DateTime? CreatedDt { get; set; }
}
