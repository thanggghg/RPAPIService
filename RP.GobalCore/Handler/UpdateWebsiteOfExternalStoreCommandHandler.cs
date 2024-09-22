using AutoMapper;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database;
using GoSell.Affiliate.Tracking.Services.Interfaces;
using GoSell.Library.Helpers.Api;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class UpdateWebsiteOfExternalStoreCommandHandler : IRequestHandler<UpdateWebsiteOrIsDeletedOfExternalStoreCommand, bool>
    {
        private readonly ILogger<UpdateWebsiteOfExternalStoreCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAffiliateStoreServices _affiliateStoreServices;
        private readonly AffiliateContext _affiliateContext;
        public UpdateWebsiteOfExternalStoreCommandHandler(ILogger<UpdateWebsiteOfExternalStoreCommandHandler> logger,
                                                  IBaseApi baseApi,
                                                  IMapper mapper,
                                                  IAffiliateStoreServices affiliateStoreServices,
                                                  AffiliateContext affiliateContext)
        {
            _logger = logger;
            _mapper = mapper;
            _affiliateStoreServices = affiliateStoreServices;
            _affiliateContext = affiliateContext;
        }
        public async Task<bool> Handle(UpdateWebsiteOrIsDeletedOfExternalStoreCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _affiliateContext.BeginTransactionAsync())
            {
                try
                {
                    var result = await _affiliateStoreServices.UpdateWebsiteOrIsDeletedOfExternalStoreAsync(request, cancellationToken);

                    Log.Logger.Information($"DONE {nameof(UpdateWebsiteOfExternalStoreCommandHandler)}");

                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex, $"FAIL {nameof(UpdateWebsiteOfExternalStoreCommandHandler)} : {ex.Message}");
                    Log.Logger.Information($"FAIL {nameof(UpdateWebsiteOfExternalStoreCommandHandler)}");
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
