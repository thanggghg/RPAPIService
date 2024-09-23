using RP.GobalCore.Database.Entities;
using RP.Library.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace RP.GobalCore.Database
{
    public class ERPOutsourceContext : BaseContext
    {
        public DbSet<UserConfiguration> Users { get; set; }
       
        public ERPOutsourceContext(DbContextOptions<ERPOutsourceContext> options, IMediator mediator) : base(options, mediator)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
