using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace LoginAppData
{
    public class DesignTimeLoginDataContextFactory : IDesignTimeDbContextFactory<LoginDataContext>
    {
        public LoginDataContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ConsoleApp1"))
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("postgres");

            var optionBuilder = new DbContextOptionsBuilder<LoginDataContext>();
            optionBuilder.UseNpgsql(connectionString);

            return new LoginDataContext (optionBuilder.Options);
        }
    }
}
