using ConsoleApp1.Config;
using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.AccountMethoden;
using ScottPlot.Control;
using SharedLibary;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class LtExecuter : ILtExecuter
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly IUserService _userService;
        private readonly IUserOptions _userOptions;
        private readonly IAppSettings _appSettings;
        private readonly IAdminCommands _adminCommands;
      

        public LtExecuter(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions, IAppSettings appSettings, IAdminCommands adminCommands)
        {
            _consoleHelper = consoleHelper;
            _userService = userService;
            _userOptions = userOptions;
            _appSettings = appSettings;
            _adminCommands = adminCommands;
        }


        public async void InitializeStart(string[] args)
        {
            _consoleHelper.Printer("Willkommen bei Der loginApp");
            while (true)
            {
                _consoleHelper.Printer("Um fort zu fahren drücken Sie bitte Enter");
                ConsoleKeyInfo checkEnterKey = _consoleHelper.ReadKey();
                if (checkEnterKey.Key == ConsoleKey.Enter)
                {
                    bool examination = true;
                    while (examination)
                    {
                        var requestedOption = _userOptions.OptionSelector();
                        switch (requestedOption)
                        {
                            case Options.ProgrammVerlassen:
                                Environment.Exit(0);
                                break;

                            case Options.NeuerUserRegestrieren:
                                RegistringCases();
                                break;

                            case Options.Login:
                                Task.Run(async() => await LoginCase()).Wait();
                                break;
                        }
                        examination = CheckYesNoInput(examination); 
                    }
                }
                else
                {
                    _consoleHelper.Printer("");
                    _consoleHelper.Printer("Sie haben eine falsche eingabe betätigt\n");
                }
            }
        }

        public bool CheckYesNoInput(bool examination)
        {
            _consoleHelper.Printer("Wollen sie fortfahren Y = weiter und N = für Nein");
            ConsoleKeyInfo checkKey = _consoleHelper.ReadKey();
            if (checkKey.Key == ConsoleKey.Y)
            {
                examination = true;
            }
            else if (checkKey.Key == ConsoleKey.N)
            {
                _consoleHelper.Printer("");
                _consoleHelper.Printer("Auf Wiedersehen");
                examination = false;
                Environment.Exit(0);
            }
            else
            {
                _consoleHelper.Printer("");
                _consoleHelper.Printer("bitte Geben Sie die richtige Taste ein ");
            }

            return examination;
        }

        public void RegistringCases()
        {
            var requestOptions = _userOptions.AccountsOptions();
            switch(requestOptions)
            {
                case UsersOptions.Admin:
                    _userService.CreateUser(UsersOptions.Admin);
                    break;
                case UsersOptions.User:
                    _userService.CreateUser(UsersOptions.User);
                    break;
                default:
                    _consoleHelper.Printer("Wrong Input");
                    break;
            }
        }

        public async Task LoginCase()
        {
            var requestOptions = _userOptions.AccountsOptions();
            bool loggedIn;
            switch (requestOptions)
            {
                case UsersOptions.Admin:
                    loggedIn = await _userService.LoginUser();
                    if (loggedIn)
                    {
                        await AdminCase();
                    }
                    else
                    {
                        _consoleHelper.Printer("Login is Failed");
                    }
                    break;
                case UsersOptions.User:
                    await _userService.LoginUser();
                    break;
                default:
                    _consoleHelper.Printer("Wrong Input");
                    break;
            }
        }

        public async Task AdminCase()
        {
            var examination = true;
            while (examination)
            {
                var requeustoptions = _userOptions.AdminCommands();
                _consoleHelper.Printer($"acess to D/Database or J/Jsonfiles");
                var storagePath = _consoleHelper.ReadKey();
                switch (requeustoptions)
                {
                    case Adminrights.DeleteUsersOrAdmin:
                        _consoleHelper.Printer("Folder: A/Admin or U/User");
                        var folderPath = _consoleHelper.ReadKey();
                        await StoragePath(
                            () => _adminCommands.DeleteUserOrAdminInDataBase(),
                            () =>  _adminCommands.DeleteUserOrAdminFunction(() => _userService.ChooseFolderPath(folderPath.Key == ConsoleKey.A)),
                            storagePath);
                        break;
                    case Adminrights.DeleteAllUsers:
                        await _adminCommands.DeleteAllUsersFromDataBase();
                        break;
                    case Adminrights.OutputOfAllUsers:
                        await _consoleHelper.PrintAllUsersFromDataBase("User");
                        break;
                    case Adminrights.ChangeLoginData:
                        await _adminCommands.ChangeLginDataInDatabase();
                        break;
                    case Adminrights.AdminRightsExit:
                        examination = false;
                        break;
                    default:
                        _consoleHelper.Printer("Wrong Input");
                        break;
                }
            }
        }

        public static async Task StoragePath(
            Func<Task> databaseMethod,
            Action jsonFileMethod,
            ConsoleKeyInfo storagePath)
        {
            if (storagePath.Key == ConsoleKey.D)
            {
                await databaseMethod();
            }
            else if(storagePath.Key == ConsoleKey.J)
            {
               
                jsonFileMethod();
            }
        }
    }
}


