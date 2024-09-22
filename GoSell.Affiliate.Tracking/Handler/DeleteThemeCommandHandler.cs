using System.Web;
using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Entities;
using GoSell.Affiliate.Tracking.Services;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class DeleteThemeCommandHandler : IRequestHandler<DeleteThemeCommand, bool>
    {
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public DeleteThemeCommandHandler(IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateStoreServices affiliateStoreServices)
        {
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<bool> Handle(DeleteThemeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateTheme = await _affiliateStoreServices.GetAffiliateThemeById(command.Id, cancellationToken);
                if (affiliateTheme == null)
                {
                    throw new Exception("Theme not exist");
                }
                affiliateTheme.IsDeleted = true;
                var reponses = await _affiliateStoreServices.UpdateThemeAsync(affiliateTheme, cancellationToken);
                Log.Logger.Information($"DONE {nameof(CreateAffiliateLinkCommandHandler)}");
                return await Task.FromResult(reponses);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateLinkCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
