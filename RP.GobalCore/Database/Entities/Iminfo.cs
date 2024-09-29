using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Iminfo
{
    public int ItemMasterNoPk { get; set; }

    public string ImitemId { get; set; }

    public string Imdescription { get; set; }

    public string ImcustItemId { get; set; }

    public int ImproductTypeFk { get; set; }

    public string Ptname { get; set; }

    public float Impack { get; set; }

    public string ImpackType { get; set; }

    public DateTime FgcreatedDt { get; set; }

    public string CustomerName { get; set; }

    public string RnDfhformulaCode { get; set; }

    public decimal? RnDfhversion { get; set; }

    public string RnDfhsize { get; set; }

    public string RnDfhshape { get; set; }

    public string RnDfhcolor { get; set; }

    public string RnDfhpillCavity { get; set; }

    public string RnDfhpillCavitySize { get; set; }

    public string RnDfhgelType { get; set; }

    public string RnDfhhardness { get; set; }

    public string RnDfhthickness { get; set; }

    public decimal? ImbulkIdfgitemMasterVer { get; set; }

    public int IsClearCoat { get; set; }

    public string ImcomboCodes { get; set; }
}
