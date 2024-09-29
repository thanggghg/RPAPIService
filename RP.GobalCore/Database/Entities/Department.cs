using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class Department
{
    public int DepartmentNoPk { get; set; }

    public string DeptName { get; set; }

    public int RecStatusNoFk { get; set; }

    public string DeptDescription { get; set; }

    public string Remarks { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public string LastUpdBy { get; set; }

    public DateTime LastUpdDt { get; set; }

    public bool IsForPo { get; set; }

    public string DeptEmail { get; set; }
}
