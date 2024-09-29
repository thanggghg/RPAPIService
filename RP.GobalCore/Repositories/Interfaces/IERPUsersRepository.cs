using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.GobalCore.Database.Entities;
using RP.Library.Seedwork;

namespace RP.GobalCore.Repositories.Interfaces
{
    internal interface IERPUsersRepository : IRepository<Users>
    {
        long GetUserAsyc();
    }
}
