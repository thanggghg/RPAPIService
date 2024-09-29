
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.ViewModels.Queries;

namespace RP.GobalCore.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticateLoginResponse> Login(AuthenticateLoginQueries request, CancellationToken cancellationToken);
    }
}
