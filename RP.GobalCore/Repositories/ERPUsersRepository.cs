using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RP.GobalCore.Database;
using RP.GobalCore.Repositories.Interfaces;
using RP.Library.Seedwork;

namespace RP.GobalCore.Repositories
{
    public class ERPUsersRepository(ERPOutsourceContext context) : IERPUsersRepository
    {
        private readonly ERPOutsourceContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        
        public long GetUserAsyc()
        {
            return 5;
        }
    }
}
