using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RP.GobalCore.Database.Entities
{
    [Table("Users")]
    public class UserConfiguration
    {
        [Key]
        [Column("UsersID_PK")]
        [StringLength(50)]
        public string UsersID { get; set; }

        [Column("UserSupervisorID_FK")]
        [StringLength(50)]
        public string UserSupervisorID { get; set; }

        [Column("UsersPasscode")]
        [StringLength(50)]
        public string UsersPasscode { get; set; }

        [Column("UsersMonitorCust")]
        [StringLength(3000)]
        public string UsersMonitorCust { get; set; }

        [Column("UserForcePassChange")]
        public bool UserForcePassChange { get; set; }

        [Column("UserDateToExpired")]
        public int UserDateToExpired { get; set; }

        [Column("RecStatusNo_FK")]
        public int RecStatusNo { get; set; }

        [Column("UsersLastName")]
        [StringLength(25)]
        public string UsersLastName { get; set; }

        [Column("UsersFirstName")]
        [StringLength(25)]
        public string UsersFirstName { get; set; }

        [Column("UsersMidName")]
        [StringLength(25)]
        public string UsersMidName { get; set; }

        [Column("UsersLocDesc")]
        [StringLength(50)]
        public string UsersLocDesc { get; set; }

        [Column("UserPassChangeDate")]
        public DateTime? UserPassChangeDate { get; set; }

        [Column("UsersCreatedDt")]
        public DateTime UsersCreatedDt { get; set; }

        [Column("UsersCreatedBy")]
        [StringLength(50)]
        public string UsersCreatedBy { get; set; }

        [Column("UsersLastUpdDt")]
        public DateTime UsersLastUpdDt { get; set; }

        [Column("UsersLastUpdBy")]
        [StringLength(50)]
        public string UsersLastUpdBy { get; set; }

        [Column("defForCustomer")]
        public int? DefForCustomer { get; set; }

        [Column("ViewAllQuotes")]
        public bool ViewAllQuotes { get; set; }

        [Column("RPRMview")]
        public bool RPRMview { get; set; }

        [Column("crtNewQnumOnly")]
        public bool CrtNewQnumOnly { get; set; }

        [Column("EditNewBOM")]
        public bool EditNewBOM { get; set; }

        [Column("UpdateStdCost")]
        public bool UpdateStdCost { get; set; }

        [Column("RMViewHisNote")]
        public bool RMViewHisNote { get; set; }

        [Column("RMViewPOBatch")]
        public bool RMViewPOBatch { get; set; }

        [Column("EditSOPkgAfterBOM")]
        public bool EditSOPkgAfterBOM { get; set; }

        [Column("EditPOAfterRecv")]
        public bool EditPOAfterRecv { get; set; }

        [Column("CloseOrVoidSO")]
        public bool CloseOrVoidSO { get; set; }

        [Column("WinLogonID")]
        [StringLength(50)]
        public string WinLogonID { get; set; }

        [Column("UserLogonDt")]
        public DateTime? UserLogonDt { get; set; }

        [Column("UserLogOffDt")]
        public DateTime? UserLogOffDt { get; set; }

        [Column("EditRFQDoc")]
        public bool EditRFQDoc { get; set; }

        [Column("EditPkgBatch")]
        public bool EditPkgBatch { get; set; }

        [Column("UsersToken")]
        [StringLength(50)]
        public string UsersToken { get; set; }

        [Column("UsersWebPwd")]
        [StringLength(50)]
        public string UsersWebPwd { get; set; }

        [Column("UsersForgotPwdId")]
        [StringLength(250)]
        public string UsersForgotPwdId { get; set; }

        [Column("UsersDepartment")]
        [StringLength(50)]
        public string UsersDepartment { get; set; }

        [Column("UsersEmail")]
        [StringLength(250)]
        public string UsersEmail { get; set; }

        [Column("UsersFCMToken")]
        [StringLength(500)]
        public string UsersFCMToken { get; set; }

        [Column("LikeBackground")]
        public bool LikeBackground { get; set; }

        [Column("RecvNotification")]
        public bool RecvNotification { get; set; }

        [Column("ApprovePO")]
        public bool ApprovePO { get; set; }

        [Column("Signature")]
        public byte[] Signature { get; set; }

        [Column("TitleID")]
        [StringLength(20)]
        public string TitleID { get; set; }

        [Column("Picture")]
        public byte[] Picture { get; set; }

        [Column("sPicture")]
        public byte[] SPicture { get; set; }
    }
}
