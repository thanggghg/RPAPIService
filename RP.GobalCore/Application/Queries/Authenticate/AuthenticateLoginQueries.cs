using RP.Library.Helpers;
using MediatR;
using DocumentFormat.OpenXml.Bibliography;
using Serilog;
using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using RP.GobalCore.ViewModels.Queries;

namespace RP.GobalCore.Application.Queries.Authenticate
{
    public class AuthenticateLoginQueries : IRequest<GenericResponse<AuthenticateLoginResponse>>
    {
        public virtual string UserName { get; set; }
        public string SupervisorName { get; set; }
        public virtual string Password { get; set; }

    }
}
