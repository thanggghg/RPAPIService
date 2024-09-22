using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Commons.Enums;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Library.Helpers;
using RP.Library.Helpers.Service;
using MediatR;
using RP.GobalCore.Application.Commands.AuthenticateCommand;
using RP.GobalCore.Application.Queries.Authenticate;

namespace RP.GobalCore.Application.Handler.AuthenticateHandler
{
    public class AuthenticateHandler(IMapper mapper,
                                          IBaseService baseService
                                      ) : IRequestHandler<AuthenticateLoginCommand, BaseResponseCode>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseService _baseService = baseService;
        public async Task<BaseResponseCode> Handle(AuthenticateLoginCommand request, CancellationToken cancellationToken)
        {

        }


    }
}
