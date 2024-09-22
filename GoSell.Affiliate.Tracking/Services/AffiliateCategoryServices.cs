using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GoSell.Affiliate.Tracking.Services
{
    public class AffiliateCategoryServices
    {
        public IMediator Mediator { get; set; }
        public ILogger<AffiliateCategoryServices> Logger { get; }
        public AffiliateCategoryServices(IMediator mediator, ILogger<AffiliateCategoryServices> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }
    }
}
