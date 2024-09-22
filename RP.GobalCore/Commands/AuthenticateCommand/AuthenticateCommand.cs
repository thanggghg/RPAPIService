using RP.Library.Helpers;
using MediatR;
using DocumentFormat.OpenXml.Bibliography;
using Serilog;
using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace RP.Affiliate.Tracking.Commands.AffiliateCampaign
{
    public class AuthenticateCommand : IRequest<GenericResponse<>>
    {
        public virtual string UserName { get; set; }
        public string SupervisorName { get; set; }
        public virtual string Password { get; set; }

    }
}
