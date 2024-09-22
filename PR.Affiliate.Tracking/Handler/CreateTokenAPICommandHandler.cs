using System.Management;
using DocumentFormat.OpenXml.Wordprocessing;
using GoSell.Affiliate.Tracking.Commands;
using GoSell.Affiliate.Tracking.Database.Entities;
using GoSell.Affiliate.Tracking.Functions.Interface;
using GoSell.Library.Extensions.JWT;
using GoSell.Library.Helpers;
using GoSell.Library.Utils;
using MediatR;
using Serilog;

namespace GoSell.Affiliate.Tracking.Handler
{
    public class CreateTokenAPICommandHandler : IRequestHandler<CreateTokenAPICommand, string>
    {
        private readonly JwtOptions _jwtOptions;
        public CreateTokenAPICommandHandler(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public Task<string> Handle(CreateTokenAPICommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jwtVerifier = new JwtVerifier(_jwtOptions);

                var token = jwtVerifier.BuildTokenAPI("system", AuthoritiesConstants.AFFILIATE, request.AffiliateStoreId,request.APIKey);
                Log.Logger.Information($"DONE {nameof(CreateApiKeyCommandHandler)}");
                return Task.FromResult(token);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(CreateApiKeyCommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
