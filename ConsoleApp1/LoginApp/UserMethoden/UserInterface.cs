using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;


namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserInterface
    {
        private IConsoleHelper consoleHelper;
        private IUserService userService;
        private IUserOptions userOptions; 


        public UserInterface(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions)
        {
            this.consoleHelper = consoleHelper;
            this.userService = userService;
            this.userOptions = userOptions;
            
        }

        public List<User> StoredUsers { get; set; } = new List<User>();
        public void Main()
        {
            InitializeStart();
        }


        public void InitializeStart()
        {
            consoleHelper.Printer("Willkommen bei Der loginApp");
            Thread.Sleep(400);
            while (true)
            {
                Thread.Sleep(600);
                consoleHelper.Printer("Um fort zu fahren drücken Sie bitte Enter");
                ConsoleKeyInfo checkEnterKey = consoleHelper.ReadKey();
                if (checkEnterKey.Key == ConsoleKey.Enter)
                {
                    bool examination = true;
                    while (examination)
                    {
                        var requestedOption = userOptions.OptionSelector();
                        switch (requestedOption)
                        {
                            case Options.ProgrammVerlassen:
                                Environment.Exit(0);
                                break;

                            case Options.NeuerUserRegestrieren:
                                userService.CreateUser(StoredUsers);
                                break;

                            case Options.Login:
                                userService.LoginUser(StoredUsers);
                                break;

                            case Options.OutputofAllUser:
                                consoleHelper.PrintAllUsers(StoredUsers);
                                break;
                        }
                        consoleHelper.Printer("Wollen sie fortfahren Y = weiter und N = für Nein");
                        ConsoleKeyInfo checkKey = consoleHelper.ReadKey();
                        if (checkKey.Key == ConsoleKey.Y)
                        {
                            examination = true;
                        }
                        else if (checkKey.Key == ConsoleKey.N)
                        {
                            consoleHelper.Printer("");
                            consoleHelper.Printer("Auf Wiedersehen");
                            examination = false;
                            Environment.Exit(0);
                        }
                        else if (checkKey.Key != ConsoleKey.Y && checkKey.Key != ConsoleKey.N)
                        {
                            consoleHelper.Printer("");
                            consoleHelper.Printer("bitte Geben Sie die richtige Taste ein ");
                        }
                    }
                }
                else if (checkEnterKey.Key != ConsoleKey.Enter)
                {
                    consoleHelper.Printer("");
                    consoleHelper.Printer("Sie haben eine falsche eingabe betätigt\n");
                }
            }
        }
    }
}
