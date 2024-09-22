using Microsoft.AspNetCore.Authorization;
using RP.Library.Enums;
namespace RP.Library.Extensions.Permission
{
    public class StaffPermissionRequirement : IAuthorizationRequirement
    {
        public StaffPermissionRequirement(List<StaffPermissionEnum> staffPermissions) { StaffPermissions = staffPermissions; }
        public List<StaffPermissionEnum> StaffPermissions { get; set; }
    }
}
