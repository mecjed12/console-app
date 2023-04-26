using ConsoleApp1.Helper;

namespace ConsoleApp1.LoginApp.Registrie
{
    public class Registring : IRegistring
    {

        private readonly IConsoleHelper consoleHelper;

        public Registring(IConsoleHelper consoleHelper)
        {
            this.consoleHelper = consoleHelper;
        }

        public string RegistryName()
        {
            consoleHelper.Printer("Bitte geben Sie Ihre Namen ein ");
            var name = consoleHelper.ReadInput();
            int numberComparator;
            bool nameIsWrong = true;
            while (nameIsWrong)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (int.TryParse(name, out numberComparator))
                    {
                        consoleHelper.Printer("Bitte geben sie Buchstaben und keine nummern ein\n");
                        consoleHelper.Printer("Bitte geben Sie Ihre Namen ein ");
                        name = consoleHelper.ReadInput();
                    }
                    else
                    {
                        nameIsWrong = false;
                    }
                }
                else
                {
                    consoleHelper.Printer("Falsche Eingabe. Bitte Geben Sie Ihren Namen erneut ein");
                    name = consoleHelper.ReadInput();
                }
            }
            return name;
        }

        public int RegistryPassword()
        {
            consoleHelper.Printer("Bitte geben Sie ihr gewünschtes Passwort ein ");
            var password = consoleHelper.ReadInput();
            int numberComparator;
            bool numberIsWrong = true;
            while (numberIsWrong)
            {
                if (password != null)
                {
                    if (int.TryParse(password, out numberComparator))
                    {
                        numberIsWrong = false;
                    }
                    else
                    {
                        consoleHelper.Printer("Bitte geben sie eine Nummer und keinen Buchstaben ein\n");
                        consoleHelper.Printer("Bitte geben Sie ihr gewünschtes Passwort ein ");
                        password = consoleHelper.ReadInput();
                    }
                }
            }
            return consoleHelper.IntConvertor_String(password);
        }
    }
}
