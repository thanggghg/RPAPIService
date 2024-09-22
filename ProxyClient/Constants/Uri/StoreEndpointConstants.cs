using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClient.Constants.Uri
{
    internal class StoreEndpointConstants
    {
        public const string GET_STORE_BY_ID = "/storeservice/api/stores/{0}";
        public const string GET_STORE_BY_OWNER = "/storeservice/api/stores/user/{0}";
        public const string GET_ALL_STAFF_BRANCHES = "/storeservice/api/staff-branches?page={0}&size={1}";
        public const string FIND_STORE_STAFF = "/storeservice/api/store-staffs/find/{0}?isActive={1}&isEnabledCC=false";

    }
}
