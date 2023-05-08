using Microsoft.EntityFrameworkCore;

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
        public DbSet<ToDoListModel> ToDoList { get; set; }

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
