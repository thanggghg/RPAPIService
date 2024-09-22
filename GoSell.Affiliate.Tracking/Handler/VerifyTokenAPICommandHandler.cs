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
    public class VerifyTokenAPICommandHandler : IRequestHandler<VerifyTokenAPICommand, PayloadJWT>
    {
        private readonly JwtOptions _jwtOptions;
        public VerifyTokenAPICommandHandler(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public Task<PayloadJWT> Handle(VerifyTokenAPICommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jwtVerifier = new JwtVerifier(_jwtOptions);
                var payload = jwtVerifier.VerifyTokenAPI( request.token);
                Log.Logger.Information($"DONE {nameof(VerifyTokenAPICommandHandler)}");
                return Task.FromResult(payload);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"FAIL {nameof(VerifyTokenAPICommandHandler)} : {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
