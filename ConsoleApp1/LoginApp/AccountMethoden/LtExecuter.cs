using ConsoleApp1.Config;
using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Tools;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;
using System.Diagnostics.Contracts;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class LtExecuter : ILtExecuter
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly IUserService _userService;
        private readonly IUserOptions _userOptions;
        private readonly IAppSettings _appSettings;
      

        public LtExecuter(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions,IAppSettings appSettings)
        {
            _consoleHelper = consoleHelper;
            _userService = userService;
            _userOptions = userOptions;
            _appSettings = appSettings;
        }

      

        public void InitializeStart(string[] args)
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
                                LoginCase();
                                break;

                            case Options.OutputofAllUser:
                                _consoleHelper.PrintAllUsers(_appSettings.UsersFolderPath);
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
                    _userService.CreateUser(_appSettings.AdminFolderPath);
                    break;
                case UsersOptions.User:
                    _userService.CreateUser(_appSettings.UsersFolderPath);
                    break;
            }
        }

        public void LoginCase()
        {
            var requestOptions = _userOptions.AccountsOptions();
            switch (requestOptions)
            {
                case UsersOptions.Admin:
                    _userService.LoginUser(_appSettings.AdminFolderPath);
                    break;
                case UsersOptions.User:
                    _userService.LoginUser(_appSettings.UsersFolderPath);
                    break;
            }
        }
    }
}
