namespace ConsoleApp1.LoginApp.Registrie
{
    public class EnumOptions : IEnumOptions
    {
        public enum Options
        {
            ProgrammVerlassen = 0,
            NeuerUserRegestrieren = 1,
            Login = 2,
            OutputofAllUser = 3,
        }

        public enum UsersOptions
        {
            Admin = 0,
            User = 1,
        }

        public enum Adminrights
        {
            DeleteUsers = 0,
            DeleteAllUsers = 1,
            OutputOfAllUsers = 2,
            DeleteAdmin = 3,
            ChangeLoginData = 4,
        }

        public void AllOptionsPrinter<TEnum>() where TEnum : Enum
        {
            Console.WriteLine("");
            Console.WriteLine("Sie können diese Optionen auswählen:");

            var temp = Enum.GetNames(typeof(TEnum));

            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine($" {i} for {temp[i]}");
            }
        }
    }
}

