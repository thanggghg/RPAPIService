using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class FgcoaheaderLog
{
    public int FgcoaheaderLogPk { get; set; }

    public int? FgcoaheaderPk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string Imcode { get; set; }

    public string Imversion { get; set; }

    public string Imdesc { get; set; }

    public string Imsize { get; set; }

    public string Imcolor { get; set; }

    public DateTime ProdMfgDate { get; set; }

    public string ProdExpDate { get; set; }

    public DateTime? CoaissueDate { get; set; }

    public string Brlot { get; set; }

    public string Coaversion { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public string ImgelColor { get; set; }

    public string IntlDesc { get; set; }

    public string CustCode { get; set; }

    public string ServingSize { get; set; }

    public string ExpiredIn { get; set; }

    public string PkgDate { get; set; }

    public string PkgBatch { get; set; }

    public string Notes { get; set; }
}
