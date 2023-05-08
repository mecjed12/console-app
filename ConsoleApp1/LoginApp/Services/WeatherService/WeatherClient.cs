using OpenMeteo;

namespace ConsoleApp1.LoginApp.Services.Weatherservices
{
    using ConsoleApp1.Config;
    using ConsoleApp1.Helper;
    using OfficeOpenXml;

    public class WeatherClient : IWeatherClient
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly IAppSettings _appSettings;

        public WeatherClient(IConsoleHelper consoleHelper,IAppSettings appSettings)
        {
            _consoleHelper = consoleHelper;
            _appSettings = appSettings;
        }

        public async Task RunAsync()
        {
            _consoleHelper.Printer("Witch City");
            var city = _consoleHelper.ReadInput();
            OpenMeteoClient client = new OpenMeteoClient();

            WeatherForecast? weatherData = await client.QueryAsync(city);

            _consoleHelper.Printer($"Temperature in {city}: " + weatherData.CurrentWeather.Temperature + "°C\n");
            _consoleHelper.Printer("Wind speed: " + weatherData.CurrentWeather.Windspeed + "km/H\n");

            CreateAExcelSheet(city, weatherData);
        }

        private void CreateAExcelSheet(string city, WeatherForecast weatherForecast)
        {
            var excelPackage = new ExcelPackage();

            var worksheet = excelPackage.Workbook.Worksheets.Add("Weather Data");

            worksheet.Cells[1, 1].Value = "City";
            worksheet.Cells[1, 2].Value = "Temperature (C°)";
            worksheet.Cells[1, 3].Value = "Wind Speed (km/H)";

            worksheet.Cells[2, 1].Value = city;
            worksheet.Cells[2, 2].Value = weatherForecast.CurrentWeather.Temperature;
            worksheet.Cells[2, 3].Value = weatherForecast.CurrentWeather.Windspeed;


            var fileStream = new FileStream(_appSettings.WeatherFolderPath +"\\Weatherdata.xlsx",FileMode.Create);
            excelPackage.SaveAs(fileStream);
            fileStream.Close();

            _consoleHelper.Printer("Weather data saved to Excel file");
        }
    }
}
