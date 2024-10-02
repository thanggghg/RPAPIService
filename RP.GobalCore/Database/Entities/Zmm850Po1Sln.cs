using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Po1Sln
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public int? SlnRowId { get; set; }

    public string SlnPo { get; set; }

    public DateTime? SlnPoDate { get; set; }

    public string SlnPoItemLineNumber { get; set; }

    public string Sln01Identification { get; set; }

    public string Sln02Identification { get; set; }

    public string Sln03RelationshipCd { get; set; }

    public double? Sln04Qty { get; set; }

    public string Sln05Unit { get; set; }

    public string C00101UnitCd { get; set; }

    public double? C00102Exponent { get; set; }

    public double? Sln06UnitPrice { get; set; }

    public string Sln07UnitPriceCd { get; set; }

    public string Sln08RelationshipCd { get; set; }

    public string Sln09ProductIdq { get; set; }

    public string Sln10ProductId { get; set; }

    public string Sln11ProductIdq { get; set; }

    public string Sln12ProductId { get; set; }

    public string Sln13ProductIdq { get; set; }

    public string Sln14ProductId { get; set; }

    public string Sln15ProductIdq { get; set; }

    public string Sln16ProductId { get; set; }

    public string Sln17ProductIdq { get; set; }

    public string Sln18ProductId { get; set; }

    public string Sln19ProductIdq { get; set; }

    public string Sln20ProductId { get; set; }

    public string Sln21ProductIdq { get; set; }

    public string Sln22ProductId { get; set; }

    public string Sln23ProductIdq { get; set; }

    public string Sln24ProductId { get; set; }

    public string Sln25ProductIdq { get; set; }

    public string Sln26ProductId { get; set; }

    public string Sln27ProductIdq { get; set; }

    public string Sln28ProductId { get; set; }

    public string Pid01ItemDescrType { get; set; }

    public string Pid02CharacteristicCd { get; set; }

    public string Pid03AgencyQcd { get; set; }

    public string Pid04ProdDescrCd { get; set; }

    public string Pid05Descr { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
