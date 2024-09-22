using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClient.Models.Responses.User
{
    public class UserModel
    {
        public long Id { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public string LangKey { get; set; }

        public AvatarUrlModel AvatarUrl { get; set; }

    }

    public class AvatarUrlModel
    {
        public long ImageId { get; set; }
        public string fullUrl { get; set; }
        public string Extension { get; set; }
        public string UrlPrefix { get; set; }
    }
}
