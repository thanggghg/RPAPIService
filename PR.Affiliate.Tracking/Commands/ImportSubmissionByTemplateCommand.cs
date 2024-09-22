using System.Runtime.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using Elasticsearch.Net;
using GoSell.Affiliate.Tracking.ViewModels;
using GoSell.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GoSell.Affiliate.Tracking.Commands
{
    public class ImportSubmissionByFileCommand : IRequest<ResultImportDataViewModel>
    {
        [DataMember]
        public virtual IFormFile File { get; set; }
        [DataMember]
        public virtual bool IsFileTemplate { get; set; }
        [DataMember]
        public virtual long AffiliateStoreId { get; set; }
        public virtual string ClientTimeZone { get; set; }

        public ImportSubmissionByFileCommand(IFormFile file, bool isFileTemplate, long affiliateStoreId,string clientTimeZone)
        {
            File = file;

            IsFileTemplate = isFileTemplate;

            AffiliateStoreId = affiliateStoreId;

            ClientTimeZone = clientTimeZone;
        }
    }
}
