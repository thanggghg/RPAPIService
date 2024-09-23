using System.Linq.Expressions;
using System.Web;
using RP.Affiliate.Tracking.Services.Interfaces;
using RP.Affiliate.Tracking.Utils;
using RP.Affiliate.Tracking.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using RP.GobalCore.ViewModels.Queries;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.Database;
using RP.GobalCore.Database.Entities;
using RP.API.Service;
using RP.Library.Exceptions;

namespace RP.Affiliate.Tracking.Services
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> Logger;

        private readonly ERPOutsourceContext _eRPOutsourceContext;
        private readonly IJwtTokenService _jwtTokenService;
        public AccountService(
            ILogger<AccountService> logger,
            ERPOutsourceContext eRPOutsourceContext,
            JwtTokenService jwtTokenService
           )
        {
            Logger = logger;
            _eRPOutsourceContext = eRPOutsourceContext;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthenticateLoginResponse> Login(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _eRPOutsourceContext.Users.AsQueryable();

                query = query.Where(u => u.UsersID == request.UserName.Trim());

                if (!string.IsNullOrEmpty(request.Passcode))
                {
                    query = query.Where(u => u.UsersPasscode == request.Passcode.Trim());
                }
                else
                {
                    query = query.Where(u => u.UsersWebPwd == request.Password.Trim());
                }

                var user = query.FirstOrDefault();

                if (user == null)
                {
                    throw new JWTException("User not found or invalid credentials.");
                }

                var response = new AuthenticateLoginResponse
                {
                    AccessToken = _jwtTokenService.CreateAccessToken(user),  
                    TokenType = "Bearer",
                    ExpiresIn = 3600,
                    RefreshToken = _jwtTokenService.CreateRefreshToken(user),
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Login failed for user {request.UserName}: {ex.Message}");
                throw new Exception(ex.Message); 
            }
        }


    }
}


