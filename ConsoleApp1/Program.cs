namespace Loggerterminal
{
    using ConsoleApp1.Config;
    using ConsoleApp1.Helper;
    using ConsoleApp1.LoginApp.Registrie;
    using ConsoleApp1.LoginApp.Tools;
    using ConsoleApp1.LoginApp.UserMethoden;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class Programm
    {
        public static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(typeof(Programm).Assembly.Location)!)
                .AddJsonFile("appsettings.json", false);
            var configuration = configurationBuilder.Build();
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var host = Host.CreateDefaultBuilder()
                    .ConfigureHostConfiguration(o => o.AddConfiguration(configuration))
                    .ConfigureServices((_,services) =>
                    {
                        services.AddSingleton<IAppSettings>(appSettings);
                        services.RegistringDependencies();
                    })
                    .Build();

            var ltExecuter = host.Services.GetRequiredService<ILtExecuter>();
            ltExecuter.InitializeStart(args);
        }

        public static void RegistringDependencies(this IServiceCollection services) 
        {
            services.AddSingleton<IConsoleHelper, ConsoleHelper>();
            services.AddSingleton<IRegistring, Registring>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserOptions, UserOptions>();
            services.AddSingleton<ILtExecuter, LtExecuter>();
            services.AddSingleton<IWeatherClient, WeatherClient>();
            services.AddSingleton<IAutoGpt, AutoGpt>();
            services.AddSingleton<IFileHelper, FileHelper>();
            services.AddSingleton<IEnumOptions, EnumOptions>();
        }
    }
}







