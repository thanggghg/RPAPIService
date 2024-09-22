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
    public class UpdateThemeCommandHandler : IRequestHandler<UpdateThemeCommand, bool>
    {
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        public UpdateThemeCommandHandler(IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateStoreServices affiliateStoreServices)
        {
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
        }
        public async Task<bool> Handle(UpdateThemeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var affiliateTheme = await _affiliateStoreServices.GetAffiliateThemeById(command.Id, cancellationToken);
                if (affiliateTheme == null)
                {
                    throw new Exception("Theme not exist");
                }
                affiliateTheme.IsDeleted = false;
                affiliateTheme.CoverImage = command.CoverImage;
                affiliateTheme.ColorId = command.ColorId;
                affiliateTheme.IsPublished = command.IsPublished;
                affiliateTheme.Logo = command.Logo;
                affiliateTheme.StoreId = command.StoreId;
                affiliateTheme.UpdateLastModified(_baseApi.User.Sub);
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
