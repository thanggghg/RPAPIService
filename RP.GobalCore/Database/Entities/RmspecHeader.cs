using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class RmspecHeader
{
    public int RmspecHeaderNoPk { get; set; }

    public int RmshrawMaterialNoFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public int Rmshversion { get; set; }

    public string RmshitemNumber { get; set; }

    public string RmshitemDescription { get; set; }

    public string RmshproductDesc { get; set; }

    public string RmshrnDapproveBy { get; set; }

    public string RmshqcapproveBy { get; set; }

    public DateTime? RmshrnDapproveDate { get; set; }

    public DateTime? RmshqcapproveDate { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdby { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string RnDapproveId { get; set; }

    public string QcapproveId { get; set; }

    public string RmshqaapproveBy { get; set; }

    public DateTime? RmshqaapproveDate { get; set; }

    public string QaapproveId { get; set; }

    public string ApproveBy { get; set; }

    public DateTime? ApproveDate { get; set; }

    public int? RmshstatusNoFk { get; set; }

    public virtual ICollection<RmspecDetail> RmspecDetails { get; set; } = new List<RmspecDetail>();
}
