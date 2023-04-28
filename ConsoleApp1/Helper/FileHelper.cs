using ConsoleApp1.Config;
using ConsoleApp1.LoginApp.AccountMethoden.UserInformation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Helper
{
    public class FileHelper : IFileHelper
    {
        public readonly IAppSettings _settings;
        private readonly IConsoleHelper _consoleHelper;

        public FileHelper(IAppSettings settings, IConsoleHelper consoleHelper)
        {
            _settings = settings;
            _consoleHelper = consoleHelper;
        }

        public void WriteObjectToJson<T>(T obj, string path) where T : class
        {
            var fileinfo = new FileInfo(path);
            if(fileinfo.Directory?.Exists != true)
            {
                fileinfo.Directory?.Create();
            }

            using var sw = File.CreateText(fileinfo.FullName);
            var filename = JsonConvert.SerializeObject(obj, Formatting.Indented);
            sw.WriteLine(filename);
        }

        public void WriteUserEntry(Users users,string path)
        {
            ArgumentNullException.ThrowIfNull(users);
            var timeTamp = DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss");
            var userFileName = Path.Combine(path, $"{users.Name}_{timeTamp}.json");
            WriteObjectToJson(users, userFileName);
        }
        public void WriteNewDataInTheJsonFile(string message, Users selectedUser, int selectedIndex, string[] userFiles)
        {
            var file = userFiles[selectedIndex];
            File.WriteAllText(file, JsonConvert.SerializeObject(selectedUser));
            _consoleHelper.Printer($"{message} wurde erfolgreich gändert");
        }
    }
}
