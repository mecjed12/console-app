using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;
using OpenMeteo;
using ScottPlot;

namespace ConsoleApp1.LoginApp.Tools
{
    using ConsoleGraphics;
    public class WeatherClient : IWeatherClient
    {
        private readonly IConsoleHelper _consoleHelper;

        public WeatherClient(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public async Task RunAsync()
        {
            OpenMeteo.OpenMeteoClient client = new OpenMeteo.OpenMeteoClient();

            WeatherForecast? weatherData = await client.QueryAsync("Lichtenstein");
            

            _consoleHelper.Printer("Temeperatur in Lichtenstein: " + weatherData.CurrentWeather.Temperature + "°C\n");
            _consoleHelper.Printer("WindGeschwindichkeit: " + weatherData.CurrentWeather.Windspeed + "km/H\n");
        }
    }
}
