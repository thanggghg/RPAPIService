using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class ProductCategory
{
    public int CatergoryPk { get; set; }

    public string CategoryName { get; set; }

    public int ProductClassFk { get; set; }
}
