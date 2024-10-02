using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Po1Po4
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string Po4po { get; set; }

    public DateTime? Po4poDate { get; set; }

    public string Po4poitemLineNumber { get; set; }

    public int? Po401Pack { get; set; }

    public double? Po402Size { get; set; }

    public string Po403Uomcd { get; set; }

    public string Po404PkgCd { get; set; }

    public string Po405WeightQ { get; set; }

    public double? Po406GrossWeightPerPack { get; set; }

    public string Po407Uomcd { get; set; }

    public double? Po408GrossVolumePerPack { get; set; }

    public string Po409Uomcd { get; set; }

    public double? Po410Length { get; set; }

    public double? Po411Width { get; set; }

    public double? Po412Height { get; set; }

    public string Po413Uomcd { get; set; }

    public int? Po414InnerPack { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
