using ConsoleApp1.Helper;
using SharedLibary;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserOptions : IUserOptions
    {
        private readonly IConsoleHelper _consoleHelper;
        public UserOptions(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public Options OptionSelector()
        {
            _consoleHelper.AllOptionsPrinter<Options>();
            while (true)
            {
                try
                {
                    _consoleHelper.Printer("");
                    _consoleHelper.Printer("Geben Sie Ihre Nummer ein");
                    var userInput = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    switch (userInput)
                    {
                        case 0:
                            return Options.ProgrammVerlassen;

                        case 1:
                            return Options.NeuerUserRegestrieren;

                        case 2:
                            return Options.Login;

                        case 3:
                            return Options.OutputofAllUser;

                        default:
                            _consoleHelper.Printer("Ungültige Eingabe, Bitte wählen Sie eine der verfügbare Options");
                            break;
                    }
                }
                catch
                {
                    throw new FormatException("Geben Sie bitte eine Nummer ein");
                }
            }
        }

        public UsersOptions AccountsOptions()
        {
            _consoleHelper.AllOptionsPrinter<UsersOptions>();
            while (true)
            {
                try
                {
                    _consoleHelper.Printer("");
                    _consoleHelper.Printer("Geben Sie Ihre Nummer ein");
                    var userInput = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    switch (userInput)
                    {
                        case 0:
                            return UsersOptions.Admin;

                        case 1:
                            return UsersOptions.User;

                        default:
                            _consoleHelper.Printer("Ungültige Eingabe, Bitte wählen Sie eine der verfügbare Options");
                            break;
                    }
                }
                catch
                {
                    throw new FormatException("Geben Sie bitte eine Nummer ein");
                }
            }
        }

        public Adminrights AdminCommands()
        {
            _consoleHelper.AllOptionsPrinter<Adminrights>();
            while (true)
            {
                try
                {
                    _consoleHelper.Printer("");
                    _consoleHelper.Printer("Geben Sie Ihre Nummer ein");
                    var userInput = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    switch (userInput)
                    {
                        case 0:
                            return Adminrights.DeleteUsersOrAdmin;

                        case 1:
                            return Adminrights.DeleteAllUsers;

                        case 2:
                            return Adminrights.OutputOfAllUsers;

                        case 3:
                            return Adminrights.ChangeLoginData;

                        case 4:
                            return Adminrights.AdminRightsExit;

                        default:
                            _consoleHelper.Printer("Ungültige Eingabe, Bitte wählen Sie eine der verfügbare Options");
                            break;
                    }
                }
                catch
                {
                    throw new FormatException("Geben Sie bitte eine Nummer ein");
                }
            }
        }
    }
}

