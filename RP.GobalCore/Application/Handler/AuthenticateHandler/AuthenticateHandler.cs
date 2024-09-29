using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RP.Library.Helpers;
using RP.Library.Helpers.Service;
using MediatR;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.ViewModels.Queries;
using RP.GobalCore.Services.Interfaces;
using RP.GobalCore.Services;
using Serilog;

namespace RP.GobalCore.Application.Handler.AuthenticateHandler
{
    public class AuthenticateHandler(IAccountService accountService
                                      ) : IRequestHandler<AuthenticateLoginQueries, GenericResponse<AuthenticateLoginResponse>>
    {
        private readonly IAccountService _accountService = accountService;
        public async Task<GenericResponse<AuthenticateLoginResponse>> Handle(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await  _accountService.Login(request, cancellationToken );
                return new GenericResponse<AuthenticateLoginResponse>();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(AuthenticateLoginResponse)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }


    }
}
