using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm816
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public DateTime? Processed { get; set; }

    public string Bht01StructureCd { get; set; }

    public string Bht02PurposeCd { get; set; }

    public string Bht03RefInfo { get; set; }

    public DateTime? Bht04Date { get; set; }

    public string N102HdrFrom { get; set; }

    public string Hl01Id { get; set; }

    public string Hl02ParentId { get; set; }

    public string Hl03LevelCd { get; set; }

    public string N101EntityIdCd { get; set; }

    public string N102Name { get; set; }

    public string N103IdCdQ { get; set; }

    public string N104IdCd { get; set; }

    public string N301Address1 { get; set; }

    public string N302Address1 { get; set; }

    public string N301Address2 { get; set; }

    public string N302Address2 { get; set; }

    public string N401City { get; set; }

    public string N402State { get; set; }

    public string N403Zip { get; set; }

    public string N404Country { get; set; }

    public string Ref02Duns { get; set; }

    public string Ref02Dc { get; set; }

    public string Ref02Store { get; set; }

    public string Per02ContactName { get; set; }

    public string Per04ContactPhone { get; set; }

    public DateTime? Dtm02EffectiveDate { get; set; }

    public string Asi01ActionCd { get; set; }

    public string Asi02MaintenanceCd { get; set; }

    public string Asi03StatusCd { get; set; }

    public DateTime? CreatedDt { get; set; }
}
