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

namespace RP.Affiliate.Tracking.Services
{
    public class AccountService : IAccountService
    {
        private ILogger<AccountService> Logger;

        private readonly ERPOutsourceContext _eRPOutsourceContext;
        public AccountService(
            ILogger<AccountService> logger,
            ERPOutsourceContext eRPOutsourceContext
           )
        {
            Logger = logger;
            _eRPOutsourceContext = eRPOutsourceContext;
        }

        public async Task<AuthenticateLoginResponse> Login(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {
            try
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

                    var user = query.Select(u => new UserConfiguration
                    {
                        UsersID = u.UsersID,
                        UsersLastName = u.UsersLastName,
                        UsersFirstName = u.UsersFirstName,
                        UsersEmail = u.UsersEmail,
                        UsersPasscode = takeAll ? u.UsersPasscode : null, // Trả về passcode nếu cần
                        UsersWebPwd = takeAll ? u.UsersWebPwd : null,     // Trả về password nếu cần
                                                                          // Thêm các field khác nếu cần dựa vào `takeAll`
                    }).FirstOrDefault();

                    return user; // Trả về thông tin user (hoặc null nếu không tìm thấy)
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    if (listError == null)
                        listError = new List<string>();
                    listError.Add(e.ToString());
                }

                return null;
                return result;

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateClickTrackingCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}


