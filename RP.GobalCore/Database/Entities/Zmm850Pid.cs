using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm850Pid
{
    public int PidId { get; set; }

    public string Partner { get; set; }

    public string PidPo { get; set; }

    public DateTime? PidPoDate { get; set; }

    public string Pid01ItemDescriptionType { get; set; }

    public string Pid02ProductCharacteristicCd { get; set; }

    public string Pid03AgencyQcd { get; set; }

    public string Pid04ProductDescriptionCd { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
