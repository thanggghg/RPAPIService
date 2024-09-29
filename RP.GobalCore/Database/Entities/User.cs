using System;
using System.Collections.Generic;

namespace RP.GobalCore.Database.Entities;

public partial class User
{
    public string UsersIdPk { get; set; }

    public string UserSupervisorIdFk { get; set; }

    public string UsersPasscode { get; set; }

    public string UsersMonitorCust { get; set; }

    public bool UserForcePassChange { get; set; }

    public int UserDateToExpired { get; set; }

    public int RecStatusNoFk { get; set; }

    public string UsersLastName { get; set; }

    public string UsersFirstName { get; set; }

    public string UsersMidName { get; set; }

    public string UsersLocDesc { get; set; }

    public DateTime? UserPassChangeDate { get; set; }

    public DateTime UsersCreatedDt { get; set; }

    public string UsersCreatedBy { get; set; }

    public DateTime UsersLastUpdDt { get; set; }

    public string UsersLastUpdBy { get; set; }

    public int? DefForCustomer { get; set; }

    public bool ViewAllQuotes { get; set; }

    public bool Rprmview { get; set; }

    public bool CrtNewQnumOnly { get; set; }

    public bool EditNewBom { get; set; }

    public bool UpdateStdCost { get; set; }

    public bool RmviewHisNote { get; set; }

    public bool RmviewPobatch { get; set; }

    public bool EditSopkgAfterBom { get; set; }

    public bool EditPoafterRecv { get; set; }

    public bool CloseOrVoidSo { get; set; }

    public string WinLogonId { get; set; }

    public DateTime? UserLogonDt { get; set; }

    public DateTime? UserLogOffDt { get; set; }

    public bool EditRfqdoc { get; set; }

    public bool EditPkgBatch { get; set; }

    public string UsersToken { get; set; }

    public string UsersWebPwd { get; set; }

    public string UsersForgotPwdId { get; set; }

    public string UsersDepartment { get; set; }

    public string UsersEmail { get; set; }

    public string UsersFcmtoken { get; set; }

    public bool LikeBackground { get; set; }

    public bool RecvNotification { get; set; }

    public bool ApprovePo { get; set; }

    public byte[] Signature { get; set; }

    public string TitleId { get; set; }

    public byte[] Picture { get; set; }

    public byte[] SPicture { get; set; }
}
