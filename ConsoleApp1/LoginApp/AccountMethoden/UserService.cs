using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Tools;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Linq;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserService : IUserService
    {
        private readonly IRegistring _registring;
        private readonly IConsoleHelper _consoleHelper;
        private readonly IWeatherClient _weatherClient;
        private readonly IFileHelper _fileHelper;

        public UserService(IRegistring registring, IConsoleHelper consoleHelper, IWeatherClient weatherClient,IFileHelper fileHelper)
        {
            _registring = registring;
            _consoleHelper = consoleHelper;
            _weatherClient = weatherClient;
            _fileHelper = fileHelper;
        }

        public void CreateUser(string path)
        {
            var userName = _registring.RegistryName();
            var password = _registring.RegistryPassword();
            _consoleHelper.Printer("Sie haben sich erfolgreich registriert");
            var newUser = new User 
            {
                Name = userName,
                Password = password,
                CreateAt = DateTime.Now,
            };
            _fileHelper.WriteUserEntry(newUser,path);
        }

        public bool LoginUser(string folderPath)
        {
            _consoleHelper.Printer("Bitte geben Sie ihren Username ein");
            var user = FindUser(folderPath);
            if (user == null )
            {
                return false;
            }

            return PasswordCheckOver(user);
        }

        public User FindUser(string folderPath)
        {
            string requestedUserName = _consoleHelper.ReadInput();
            string[] userFiles = Directory.GetFiles(folderPath, "*.json");
            User foundUser = userFiles
                .Select(userFile => JsonConvert.DeserializeObject<User>(File.ReadAllText(userFile)))
                .FirstOrDefault(user => user.Name == requestedUserName);

            if (foundUser == null)
            {
                _consoleHelper.Printer("Dieser User exestiert nicht");
            }
            return foundUser;
        }


        public bool PasswordCheckOver(User user)
        {
            _consoleHelper.Printer("Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var password = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    if (password == user.Password)
                    {
                        break;
                    }
                    else
                    {
                        _consoleHelper.Printer($"Sie haben das Passwort falsch eingegben bitte geben sie es erneut ein ");
                        _consoleHelper.Printer($"Sie haben noch {3 - i} versuche");
                    }
                }
                catch
                {
                    throw new FormatException("Bitte geben Sie NUmmer ein");
                }
            }
            _consoleHelper.Printer("Sie haben sich erflogreich Angemeldet");
            return true;
        }

        public bool SwitchToServices()
        {
            _consoleHelper.Printer("Wollen Sie den Service benutzen Y/N");
            ConsoleKeyInfo choiceServicesOrNot = _consoleHelper.ReadKey();
            if(choiceServicesOrNot.Key == ConsoleKey.Y)
            {
                _consoleHelper.Printer("Wollen Sie das Wetter ausgeben oder den Agenten aktivieren: Wetter/W , Agent/A");
                ConsoleKeyInfo choiceAgentOrWeather = _consoleHelper.ReadKey();
                if (choiceAgentOrWeather.Key == ConsoleKey.W)
                {
                    _weatherClient.RunAsync();
                }
                else if(choiceAgentOrWeather.Key == ConsoleKey.A)
                {
                    _autoGpt.PythonCommand();
                }
            
            }
            else if (choiceServicesOrNot.Key == ConsoleKey.N)
            {
                return false;
            }
            return true;
        }
    }
}
