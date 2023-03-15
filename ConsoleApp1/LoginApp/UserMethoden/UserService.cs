using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserService : IUserService
    {
        private IRegistring registring;
        private IConsoleHelper consoleHelper; 

        public UserService(IRegistring registring, IConsoleHelper consoleHelper )
        {
            this.registring = registring;
            this.consoleHelper = consoleHelper;
        }

        public void CreateUser(List<User> userList)
        {
            var userName = registring.RegistryName();
            var password = registring.RegistryPassword();
            consoleHelper.Printer("Sie haben sich erfolgreich registriert");
            var newUser = new User(userName, password);
            userList.Add(newUser);
        }

        public bool LoginUser(List<User> userList)
        {
            consoleHelper.Printer("Bitte geben Sie ihren Username ein");
            var user = FindUser(userList);
            if (user == null )
            {
                return false;
            }

            return PasswordCheckOver(user);
        }

        public  User FindUser(List<User> userList)
        {
            Thread.Sleep(1200);
            string requestedUserName = consoleHelper.ReadInput();
            foreach (var users in userList)
            {
                if (users.GetUserName() == requestedUserName)
                {
                    return users;
                }
            }
            consoleHelper.Printer("Dieser User exestiert nicht");
            return null;
        }


        public bool PasswordCheckOver(User user)
        {
            consoleHelper.Printer("Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var password = consoleHelper.IntConvertor_String(consoleHelper.ReadInput());
                    if (password == user.GetPassword())
                    {
                        break;
                    }
                    else
                    {
                        consoleHelper.Printer($"Sie haben das Passwort falsch eingegben bitte geben sie es erneut ein ");
                        consoleHelper.Printer($"Sie haben noch {3-i} versuche");
                    }
                }
                catch (FormatException ex)
                {
                    string exceptionMessage = "Bitte geben Sie nummer ein ";
                    consoleHelper.Printer(exceptionMessage);
                }
            }
            consoleHelper.Printer("Sie haben sich erflogreich Angemeldet");
            return true;
        }
    }
}
