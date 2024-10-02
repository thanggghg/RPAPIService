using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class SampleTracking
{
    public int RmtnoPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int RmtrcvHeaderNoFk { get; set; }

    public string RmtvendorLot { get; set; }

    public string RmtwhlotNumber { get; set; }

    public string Rmtwhname { get; set; }

    public string RmtwhpulledBy { get; set; }

    public DateTime? RmtwhpullDate { get; set; }

    public string Rmtwhnotes { get; set; }

    public DateTime? RmtsampleDate { get; set; }

    public string RmtsampledBy { get; set; }

    public string RmtbotName { get; set; }

    public string RmtextractSolvent { get; set; }

    public string RmtplantParts { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime? LastUpdDt { get; set; }
}
