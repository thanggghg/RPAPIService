using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Po1SlnPid
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public int? SlnRowId { get; set; }

    public string PidPo { get; set; }

    public DateTime? PidPoDate { get; set; }

    public string PidPoItemLineNumber { get; set; }

    public string Pid01ItedDescrType { get; set; }

    public string Pid02CharacteristicCd { get; set; }

    public string Pid03AgencyQcd { get; set; }

    public string Pid04ProductDescrCd { get; set; }

    public string Pid05Descr { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
