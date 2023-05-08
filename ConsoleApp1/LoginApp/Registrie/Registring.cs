using ConsoleApp1.Helper;
using System.Text.RegularExpressions;

namespace ConsoleApp1.LoginApp.Registrie
{
    public class Registring : IRegistring
    {

        private readonly IConsoleHelper _consoleHelper;

        public Registring(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public string RegistryName()
        {
            _consoleHelper.Printer("Please enter your names");
            var name = _consoleHelper.ReadInput();
            int numberComparator;
            bool nameIsWrong = true;
            while (nameIsWrong)
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (int.TryParse(name, out numberComparator))
                    {
                        _consoleHelper.Printer("Please enter letters and no numbers\n");
                        _consoleHelper.Printer("Please enter your names ");
                        name = _consoleHelper.ReadInput();
                    }
                    else
                    {
                        nameIsWrong = false;
                    }
                }
                else
                {
                    _consoleHelper.Printer("Wrong input. Please re-enter your name");
                    name = _consoleHelper.ReadInput();
                }
            }
            return name;
        }

        public int RegistryPassword()
        {
            var password = _consoleHelper.ReadInput();
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
                        _consoleHelper.Printer("Please enter a number and not a letter\n");
                        _consoleHelper.Printer("Please enter your desired password ");
                        password = _consoleHelper.ReadInput();
                    }
                }
            }
            return _consoleHelper.IntConvertor_String(password);
        }

        public string RegistrySecureWord()
        {
            _consoleHelper.Printer("Enter you SecureWord \n What is the name of you puppy");
            var secureWord = _consoleHelper.ReadInput();
            var secureWordRegex = "^[a-zA-Z]+$";
            bool loopCheck = true;
            while (loopCheck)
            {
                if (!string.IsNullOrWhiteSpace(secureWord))
                {
                    if (Regex.IsMatch(secureWord, secureWordRegex))
                    {
                        loopCheck = false;
                    }
                    else
                    {
                        _consoleHelper.Printer("Enter letters no signs or numbers");
                    }
                }
            }
            return secureWord;
        }
    }
}
