using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSell.Library.Helpers;
using MediatR;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class CheckDuplicateRefIdCommand : IRequest<BaseResponse>
    {
        public string Id { get; set; }
        public long? AffiliateStoreId { get; set; }
    }
}
