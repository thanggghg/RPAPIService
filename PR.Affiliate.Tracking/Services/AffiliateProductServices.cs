using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateProductServices
    {
        public IMediator Mediator { get; set; }
        public ILogger<AffiliateProductServices> Logger { get; }
        public AffiliateProductServices(IMediator mediator, ILogger<AffiliateProductServices> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
    }
}
