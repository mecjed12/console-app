namespace Loggerterminal
{
    using ConsoleApp1.Config;
    using ConsoleApp1.Helper;
    using ConsoleApp1.LoginApp.AccountMethoden;
    using ConsoleApp1.LoginApp.Registrie;
    using ConsoleApp1.LoginApp.Services.To_doListService;
    using ConsoleApp1.LoginApp.Services.Weatherservices;
    using ConsoleApp1.LoginApp.UserMethoden;
    using LoginAppData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Text.Json;

    public static class Programm
    {
        public static void Main(string[] args)
        {
            var appSettingsPath = Path.Combine(Path.GetDirectoryName(typeof(Programm).Assembly.Location)!, "appsettings.json");
            var jsonString = File.ReadAllText(appSettingsPath);

            try
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    Console.WriteLine("Succsefully parse");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to pars" + ex.ToString());
            }

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(typeof(Programm).Assembly.Location)!)
                .AddJsonFile("appsettings.json", false);
            var configuration = configurationBuilder.Build();
            var connenctionstring = configuration.GetConnectionString("postgres");
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var host = Host.CreateDefaultBuilder()
                    .ConfigureHostConfiguration(o => o.AddConfiguration(configuration))
                    .ConfigureServices((_,services) =>
                    {
                        services.AddDbContext<LoginDataContext>(o => o.UseNpgsql(connenctionstring));
                        services.AddSingleton<IAppSettings>(appSettings);
                        services.RegistringDependencies();
                    })
                    .Build();

            var ltExecuter = host.Services.GetRequiredService<ILtExecuter>();
            ltExecuter.InitializeStart(args);
        }

        public static void RegistringDependencies(this IServiceCollection services) 
        {
            services.AddScoped<IConsoleHelper, ConsoleHelper>();
            services.AddScoped<IRegistring, Registring>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserOptions, UserOptions>();
            services.AddScoped<ILtExecuter, LtExecuter>();
            services.AddScoped<IWeatherClient, WeatherClient>();
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddScoped<IAdminCommands, AdminCommands>();
            services.AddScoped<ILoginDataContext, LoginDataContext>();
            services.AddScoped<IToDoList, ToDoList>();
        }
    }
}







