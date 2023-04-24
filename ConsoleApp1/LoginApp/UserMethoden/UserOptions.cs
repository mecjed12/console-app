using ConsoleApp1.LoginApp.Registrie;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserOptions : IUserOptions
    {
        private readonly IConsoleHelper consoleHelper;
        public UserOptions(IConsoleHelper consoleHelper)
        {
            this.consoleHelper = consoleHelper;
        }

        public Options OptionSelector()
        {
            consoleHelper.Printer("");
            consoleHelper.Printer("Sie können Diese Optionen auswählen");
            var temp = Enum.GetNames<Options>();

            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine($" {i} for " + temp[i]);
            }

            while (true)
            {
                try
                {
                    consoleHelper.Printer("");
                    consoleHelper.Printer("Geben Sie Ihre Nummer ein");
                    var userInput = consoleHelper.IntConvertor_String(consoleHelper.ReadInput());
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
                            consoleHelper.Printer("Ungültige Eingabe, Bitte wählen Sie eine der verfügbare Options");
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
