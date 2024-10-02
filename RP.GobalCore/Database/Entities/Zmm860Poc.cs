using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Zmm860Poc
{
    public int Id { get; set; }

    public string Partner { get; set; }

    public int? PorowId { get; set; }

    public string Pocpo { get; set; }

    public DateTime? PocpoDate { get; set; }

    public string Poc01AssignedIdentification { get; set; }

    public string Poc02ChangeCd { get; set; }

    public double? Poc03QtyOrdered { get; set; }

    public double? Poc04QtyLeftToRcv { get; set; }

    public string Poc05Unit { get; set; }

    public double? Poc06UnitPrice { get; set; }

    public string Poc07UnitPriceCd { get; set; }

    public string Poc08ProductIdq { get; set; }

    public string Poc09ProductId { get; set; }

    public string Poc10ProductIdq { get; set; }

    public string Poc11ProductId { get; set; }

    public string Poc12ProductIdq { get; set; }

    public string Poc13ProductId { get; set; }

    public DateTime? CreatedDt { get; set; }

    public DateTime? GentranDateStamp { get; set; }

    public DateTime? GentranTimeStamp { get; set; }
}
