using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyClient.Models.Responses.Store
{
    public class StaffBranchModel
    {
        public long Id { get; set; }

        public long StaffId { get; set; }

        public long BranchId { get; set; }
    }
}
