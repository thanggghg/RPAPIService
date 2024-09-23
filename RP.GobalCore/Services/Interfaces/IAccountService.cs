using RP.Affiliate.Tracking.Entities;
using RP.Affiliate.Tracking.ViewModels;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.ViewModels.Queries;

namespace RP.Affiliate.Tracking.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticateLoginResponse> login(AuthenticateLoginQueries request, CancellationToken cancellationToken);
    }
}
