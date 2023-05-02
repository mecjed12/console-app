using OpenMeteo;

namespace ConsoleApp1.LoginApp.Services.Weatherservices
{
    using ConsoleApp1.Helper;
    public class WeatherClient : IWeatherClient
    {
        private readonly IConsoleHelper _consoleHelper;

        public WeatherClient(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public async Task RunAsync()
        {
            _consoleHelper.Printer("Witch City");
            var city = _consoleHelper.ReadInput();
            OpenMeteoClient client = new OpenMeteoClient();

            WeatherForecast? weatherData = await client.QueryAsync(city);

            _consoleHelper.Printer($"Temperature in {city}: " + weatherData.CurrentWeather.Temperature + "°C\n");
            _consoleHelper.Printer("Wind speed: " + weatherData.CurrentWeather.Windspeed + "km/H\n");
        }
    }
}
