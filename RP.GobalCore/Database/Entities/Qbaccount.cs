using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Qbaccount
{
    public int Qbaid { get; set; }

    public string QbaaccountName { get; set; }

    public string QbaaccountDescription { get; set; }

    public string QbaaccountType { get; set; }

    public string QbaaccountTypeShort { get; set; }

    public string QbarefNum { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }
}
