using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class UsersRequest
{
    public string UsersReqIdPk { get; set; }

    public string UsersReqSupervisorIdFk { get; set; }

    public int RecStatusNoFk { get; set; }

    public string UsersReqLastName { get; set; }

    public string UsersReqFirstName { get; set; }

    public string UsersReqMidName { get; set; }

    public string ReqWinLogonId { get; set; }

    public string UsersReqDepartment { get; set; }

    public string UsersReqEmail { get; set; }

    public DateTime? UsersReqDate { get; set; }

    public string UsersReqBy { get; set; }

    public string UsersReqTitleId { get; set; }
}
