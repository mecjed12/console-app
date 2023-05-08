namespace ConsoleApp1.Config
{
    public interface IAppSettings
    {
        string UsersFolderPath { get; set; }
        string AdminFolderPath { get; set; }
        string WeatherFolderPath { get; set; }
    }
}
