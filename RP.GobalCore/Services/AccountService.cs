using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using RP.GobalCore.Database.Entities;
using RP.GobalCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using RP.API.Service;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.Database;
using RP.GobalCore.Repositories;
using RP.GobalCore.ViewModels.Queries;
using RP.GobalCore.Mapper;

namespace RP.GobalCore.Services
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> _logger;
        private readonly IERPOutsourceRepository<Users> _eRPUsersRepository;
        private readonly ErpoutsourceContext _context;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountService(
            ILogger<AccountService> logger,
            IERPOutsourceRepository<Users> eRPUsersRepository,
            IJwtTokenService jwtTokenService,
            ErpoutsourceContext context)
        {
            _logger = logger;
            _eRPUsersRepository = eRPUsersRepository;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        public async Task<AuthenticateLoginResponse> Login(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.Users.AsQueryable();

                query = query.Where(u => u.UsersIdPk == request.UserName.Trim());

                // Kiểm tra điều kiện mật khẩu hoặc passcode
                if (string.IsNullOrEmpty(request.Passcode))
                {
                    query = query.Where(u => u.UsersWebPwd == request.Password.Trim());
                }
                else
                {
                    query = query.Where(u => u.UsersPasscode == request.Passcode.Trim());
                }

                var user = await query.FirstOrDefaultAsync(cancellationToken);

                if (user == null)
                {
                    _logger.LogError("Login failed for user: {UserName}", request.UserName);
                    return null; // Or you can return a more specific error message or object
                }
                var userDto = user.MapUserToUserDto();
                // Assuming `AuthenticateLoginResponse` needs to be constructed
                var AccessToken = _jwtTokenService.CreateAccessToken(userDto);
                var token = _jwtTokenService.CreateAccessToken(userDto);
                return new AuthenticateLoginResponse {AccessToken = AccessToken };
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred during login: {ExceptionMessage}", e.Message);
                return null; // Or handle differently based on your error handling policies
            }
        }
    }
}
