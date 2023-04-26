

using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace ConsoleApp1.LoginApp.AccountMethoden
{
    public class AdminServices
    {
        private readonly IConsoleHelper _consoleHelper;

        public AdminServices(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public void DeleteUserOrAdminFunction(string folderPath)
        {
            var index = 0;
            string[] userFiles = Directory.GetFiles(folderPath, "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<User>(File.ReadAllText(userFile))).ToList();
            users.ForEach(user => _consoleHelper.Printer($"{index ++}. Username: {user.Name}, Passwort: {user.Password}"));

            _consoleHelper.Printer("Wählen Sie den User aus, den Sie löschen möchten (geben Sie die Nummer ein)");
            int selectIndex;
            if(int.TryParse(_consoleHelper.ReadInput(), out selectIndex) && selectIndex >= 0 && selectIndex < users.Count)
            { 
                var selectedFile = userFiles[selectIndex];
                File.Delete(selectedFile);
                _consoleHelper.Printer("Der User wurde gelöscht");
            }
            else
            {
                _consoleHelper.Printer("ungültige Auswahl");
            }
        }

        public void DeleteAllUserFunction(string folderPath)
        {
            string[] userFiles = Directory.GetFiles(folderPath, "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<User>(File.ReadAllText(userFile))).ToList() ;
            users.ForEach(user => _consoleHelper.Printer($"Username: {user.Name}, Passwort: {user.Password}"));

            userFiles.ToList().ForEach(file => File.Delete(file));
            _consoleHelper.Printer("Alle Users sind gelöscht");
        }

        public void ChangeLogData(string folderPath)
        {
            var index = 0;
            string[] userFiles = Directory.GetFiles(folderPath, "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<User>(File.ReadAllText(userFile))).ToList();
            users.ForEach(user => _consoleHelper.Printer($"{index ++}, Username: {user.Name}, Passwort: {user.Password}"));

            _consoleHelper.Printer("Wählen Sie den User aus, den Sie LoginData ändern möchten (geben Sie die Nummer ein)");
            int selectIndex;
            if(int.TryParse(_consoleHelper.ReadInput(), out selectIndex) && selectIndex >= 0 && selectIndex < users.Count)
            {
                var selectedFile = userFiles[selectIndex];
                _consoleHelper.Printer("Auswählen was sie änder wollen Username oder Passwort");
                var loginDataChange = _consoleHelper.ReadInput();
                if(loginDataChange == "Username")
                {
                    _consoleHelper.Printer("Den neuenname eingäben");
                    var newUsername = _consoleHelper.ReadInput();
                    User selectedUser = users[selectIndex];
                    selectedUser.Name = newUsername;

                    var File = userFiles[selectIndex];

                }
            }
        }
    }
}
