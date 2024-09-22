using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RP.Affiliate.Tracking.Commands.AffiliateCampaign;
using RP.Affiliate.Tracking.Commons.Constants;
using RP.Affiliate.Tracking.Commons.Enums;
using RP.Affiliate.Tracking.Database;
using RP.Affiliate.Tracking.Entities;
using RP.Library.Helpers;
using RP.Library.Helpers.Service;
using MediatR;

namespace RP.Affiliate.Tracking.Handler.AffiliateCampaignHandler
{
    public class AuthenticateHandler(IMapper mapper,
                                          IBaseService baseService
                                      ) : IRequestHandler<AuthenticateCommand, BaseResponseCode>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBaseService _baseService = baseService;
        public async Task<BaseResponseCode> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {

        }

       
    }
}
