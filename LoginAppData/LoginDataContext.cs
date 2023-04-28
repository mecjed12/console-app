using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppData
{
    public  class LoginDataContext : DbContext,ILoginDataContext
    {
        public LoginDataContext(DbContextOptions<LoginDataContext> options) :
            base(options)
        { }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Account> Accounts { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
