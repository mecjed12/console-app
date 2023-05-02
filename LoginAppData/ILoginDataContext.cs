using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppData
{
    public interface ILoginDataContext : IDisposable
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ToDoListModel> ToDoList { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
