using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Tools;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserService : IUserService
    {
        private readonly IRegistring _registring;
        private readonly IConsoleHelper _consoleHelper;
        private readonly IWeatherClient _weatherClient;

        public UserService(IRegistring registring, IConsoleHelper consoleHelper, IWeatherClient weatherClient )
        {
            this._registring = registring;
            this._consoleHelper = consoleHelper;
            this._weatherClient = weatherClient;
        }

        public void CreateUser(List<User> usersList)
        {
            var userName = _registring.RegistryName();
            var password = _registring.RegistryPassword();
            _consoleHelper.Printer("Sie haben sich erfolgreich registriert");
            var newUser = new User(userName, password);
            usersList.Add(newUser);
        }

        public bool LoginUser(List<User> usersList)
        {
            _consoleHelper.Printer("Bitte geben Sie ihren Username ein");
            var user = FindUser(usersList);
            if (user == null )
            {
                return false;
            }

            return PasswordCheckOver(user);
        }

        public User FindUser(List<User> usersList)
        {
            string requestedUserName = _consoleHelper.ReadInput();
            User? user = usersList.FirstOrDefault(o => o.GetUserName() == requestedUserName);
            if (user == null)
            {
                _consoleHelper.Printer("Dieser User exestiert nicht");
            }
            return user;
        }


        public bool PasswordCheckOver(User user)
        {
            _consoleHelper.Printer("Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var password = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    if (password == user.GetPassword())
                    {
                        break;
                    }
                    else
                    {
                        _consoleHelper.Printer($"Sie haben das Passwort falsch eingegben bitte geben sie es erneut ein ");
                        _consoleHelper.Printer($"Sie haben noch {3-i} versuche");
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
                _weatherClient.RunAsync();
            }
            else if (choiceServicesOrNot.Key == ConsoleKey.N)
            {
                return false;
            }
            return true;
        }
    }
}
