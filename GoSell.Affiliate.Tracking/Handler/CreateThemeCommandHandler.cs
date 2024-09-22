using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, bool>
    {
        private readonly IBaseApi _baseApi;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly AffiliateContext _affiliateContext;
        public CreateThemeCommandHandler(IBaseApi baseApi,
                                                 IMapper mapper,
                                                 IAffiliateStoreServices affiliateStoreServices,
                                                 AffiliateContext affiliateContext)
        {
            _baseApi = baseApi;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateContext = affiliateContext;
        }
        public async Task<bool> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {
                    var response = false;
                    var (isAlready, publishedTheme, draftTheme) = await GetThemeDataAsync(request, cancellationToken);
                    var listThemeNeedUpdate = new List<AffiliateTheme>();
                    if (isAlready)
                    {
                        if (request.IsPublished)
                        {
                            if (draftTheme != null)
                            {
                                draftTheme.UpdateLastModified(_baseApi.User.Sub);
                                draftTheme.Logo = publishedTheme.Logo;
                                draftTheme.CoverImage = publishedTheme.CoverImage;
                                draftTheme.ColorId = publishedTheme.ColorId;
                                draftTheme.AffiliateColorDefault = null;
                                listThemeNeedUpdate.Add(draftTheme);
                            }
                            else
                            {
                                var newDraftTheme = new AffiliateTheme()
                                {
                                    StoreId = publishedTheme.StoreId,
                                    ColorId = publishedTheme.ColorId,
                                    CoverImage = publishedTheme.CoverImage,
                                    Logo = publishedTheme.Logo,
                                    CreatedBy = publishedTheme.CreatedBy,
                                    CreatedDate = publishedTheme.CreatedDate,
                                    LastModifiedBy = publishedTheme.LastModifiedBy,
                                    LastModifiedDate = publishedTheme.LastModifiedDate,
                                    IsPublished = false,
                                    IsDeleted = false
                                };

                                await _affiliateStoreServices.CreateThemeAsync(newDraftTheme, cancellationToken);
                            }
                            listThemeNeedUpdate.Add(UpdateThemeBaseOnRequest(publishedTheme, request));
                        }
                        else
                        {
                            listThemeNeedUpdate.Add(UpdateThemeBaseOnRequest(draftTheme, request));
                        }
                        response = await _affiliateStoreServices.UpdateRangeThemeAsync(listThemeNeedUpdate, cancellationToken);
                    }
                    else
                    {
                        var affiliateTheme = _mapper.Map<AffiliateTheme>(request);
                        affiliateTheme.UpdateCreatedBy(_baseApi.User.Sub);
                        affiliateTheme.LastModifiedBy = _baseApi.User.Sub;
                        affiliateTheme.LastModifiedDate = affiliateTheme.CreatedDate;
                        response = await _affiliateStoreServices.CreateThemeAsync(affiliateTheme, cancellationToken);
                    }
                    Log.Logger.Information($"DONE {nameof(CreateAffiliateLinkCommandHandler)}");
                    if (response)
                        transaction.Commit();
                    else
                        transaction.Rollback();

                    return await Task.FromResult(response);
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex, $"FAIL {nameof(CreateAffiliateLinkCommandHandler)} : {ex.Message}");
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        private async Task<(bool, AffiliateTheme, AffiliateTheme)> GetThemeDataAsync(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var isAlready = false;
            var currentThemes = await _affiliateStoreServices.GetAllAffiliateThemeByStoreId(request.StoreId, cancellationToken);
            var publishedTheme = currentThemes.Where(x => x.IsPublished == true).FirstOrDefault();
            var draftTheme = currentThemes.Where(x => x.IsPublished == false).FirstOrDefault();

            if (publishedTheme != null && request.IsPublished)
            {
                isAlready = true;
            }

            if (draftTheme != null && !request.IsPublished)
            {
                isAlready = true;
            }
            return (isAlready, publishedTheme, draftTheme);
        }
        private AffiliateTheme UpdateThemeBaseOnRequest(AffiliateTheme updateTheme, CreateThemeCommand request)
        {
            if (!string.IsNullOrEmpty(request.CoverImage))
                updateTheme.CoverImage = request.CoverImage;
            if (!string.IsNullOrEmpty(request.Logo))
                updateTheme.Logo = request.Logo;
            updateTheme.ColorId = request.ColorId;
            updateTheme.IsPublished = request.IsPublished;
            updateTheme.UpdateLastModified(_baseApi.User.Sub);
            updateTheme.AffiliateColorDefault = null;
            return updateTheme;
        }
    }
}
