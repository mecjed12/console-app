using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Tools;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;


namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class LtExecuter : ILtExecuter
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly IUserService _userService;
        private readonly IUserOptions _userOptions;
        private readonly IWeatherClient _weatherClient;

        public LtExecuter(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions)
        {
            this._consoleHelper = consoleHelper;
            this._userService = userService;
            this._userOptions = userOptions;
        }


        public List<User> StoredUsers { get; set; } = new List<User>();

        public void InitializeStart()
        {
            _consoleHelper.Printer("Willkommen bei Der loginApp");
            Thread.Sleep(400);
            while (true)
            {
                Thread.Sleep(600);
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
                                _userService.CreateUser(StoredUsers);
                                break;

                            case Options.Login:
                                if(_userService.LoginUser(StoredUsers))
                                {
                                    _userService.SwitchToServices();
                                }
                                break;

                            case Options.OutputofAllUser:
                                _consoleHelper.PrintAllUsers(StoredUsers);
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

       
    }
}
