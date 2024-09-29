using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Adjdiscussion
{
    public int Id { get; set; }

    public string ItemId { get; set; }

    public string Content { get; set; }

    public string FileName { get; set; }

    public string FilePath { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
