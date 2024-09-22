using Microsoft.AspNetCore.Authorization;
using GoSell.Library.Enums;
namespace GoSell.Library.Extensions.Permission
{
    public class StaffPermissionRequirement : IAuthorizationRequirement
    {
        public StaffPermissionRequirement(List<StaffPermissionEnum> staffPermissions) { StaffPermissions = staffPermissions; }
        public List<StaffPermissionEnum> StaffPermissions { get; set; }
    }
}
