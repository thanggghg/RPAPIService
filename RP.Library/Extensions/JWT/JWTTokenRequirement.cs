using Microsoft.AspNetCore.Authorization;

namespace RP.Library.Extensions.JWT
{
    public class JWTTokenRequirement : IAuthorizationRequirement
    {
        public JWTTokenRequirement(string role) => Role = role;
        public string Role { get; set; }
    }
}
