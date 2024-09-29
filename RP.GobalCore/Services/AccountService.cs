using System.Linq.Expressions;
using System.Web;
using RP.GobalCore.Services.Interfaces;
using RP.GobalCore.Utils;
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
using RP.Common.Models;
using RP.GobalCore.Repositories.Interfaces;
using RP.GobalCore.Repositories;

namespace RP.GobalCore.Services
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> Logger;

        private readonly IERPOutsourceRepository<Users> _eRPUsersRepository;
        private readonly ERPOutsourceContext _context;
        private readonly IJwtTokenService _jwtTokenService;
        public AccountService(
            ILogger<AccountService> logger,
            IERPOutsourceRepository<Users> eRPUsersRepository,
            IJwtTokenService jwtTokenService,
            ERPOutsourceContext context
           )
        {
            Logger = logger;
            _eRPUsersRepository = eRPUsersRepository;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        public async Task<AuthenticateLoginResponse> Login(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {
            try
            {

                var randomUser = await _context.Users
                     .FirstOrDefaultAsync();       // Lấy bản ghi đầu tiên từ kết quả
                var user1 =  _eRPUsersRepository.Filter(null);
                var user = await _eRPUsersRepository.Filter(u => u.UsersID == request.UserName.Trim()).FirstOrDefaultAsync();

                // query = query.Where(u => u.UsersID == request.UserName.Trim());

                //if (!string.IsNullOrEmpty(request.Passcode))
                //{
                //    query = query.Where(u => u.UsersPasscode == request.Passcode.Trim());
                //}
                //else
                //{
                //    query = query.Where(u => u.UsersWebPwd == request.Password.Trim());
                // }


                //var user = await query.FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new JWTException("User not found or invalid credentials.");
                }

                var userDto = new UserDto
                {
                    UserName = user.UsersID,  
                    Token = Guid.NewGuid().ToString(),
                    Email = user.UsersEmail,
                    SupervisorName = user.UserSupervisorID 
                };

                var response = new AuthenticateLoginResponse
                {
                    AccessToken = _jwtTokenService.CreateAccessToken(userDto),  
                    TokenType = "Bearer",
                    ExpiresIn = 3600,
                    RefreshToken = _jwtTokenService.CreateAccessToken(userDto),
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


