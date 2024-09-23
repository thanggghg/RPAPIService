using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RP.Library.Helpers;
using RP.Library.Helpers.Service;
using MediatR;
using RP.GobalCore.Application.Queries.Authenticate;
using RP.GobalCore.ViewModels.Queries;

namespace RP.GobalCore.Application.Handler.AuthenticateHandler
{
    public class AuthenticateHandler(IMapper mapper,
                                          IBaseService baseService
                                      ) : IRequestHandler<AuthenticateLoginQueries, GenericResponse<AuthenticateLoginResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseService _baseService = baseService;
        public async Task<GenericResponse<AuthenticateLoginResponse>> Handle(AuthenticateLoginQueries request, CancellationToken cancellationToken)
        {

            await Task.CompletedTask;
            return new GenericResponse<AuthenticateLoginResponse>();

        }


    }
}
