using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgitemMasterComboId
{
    public int ImcomboIdPk { get; set; }

    public int FgcitemMasterFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int Im1Fk { get; set; }

    public int? Im2Fk { get; set; }

    public int? Im3Fk { get; set; }

    public int? Im4Fk { get; set; }

    public int? Im5Fk { get; set; }

    public int? Im6Fk { get; set; }

    public int? Im7Fk { get; set; }

    public int? Im8Fk { get; set; }

    public int? Im9Fk { get; set; }

    public int? Im10Fk { get; set; }

    public string ImcomboCodes { get; set; }

    public DateTime CreatedDt { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string LastUpdBy { get; set; }
}
