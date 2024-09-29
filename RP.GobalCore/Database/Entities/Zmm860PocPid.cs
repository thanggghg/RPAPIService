using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860PocPid
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string Pidpo { get; set; }

    public DateTime? PidpoDate { get; set; }

    public string PidpoitemLineNumber { get; set; }

    public string Pid01ItemDescrType { get; set; }

    public string Pid02CharacteristicCd { get; set; }

    public string Pid03AgencyQcd { get; set; }

    public string Pid04ProdDescrCd { get; set; }

    public string Pid05Descr { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
