using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class ConsoleHelper : IConsoleHelper
    {
        public void Printer(string output)
        {
            Console.WriteLine(output);
        }

        public int IntConvertor_String (string number)
        {          
            return Convert.ToInt32(number);
        }

        public int IntConvertor_Int(int number)
        {
            return Convert.ToInt32(number);
        }


        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }

        public void PrintTheUser (string name, int password)
        {
            Thread.Sleep(3000);
            Printer($"Willkomen : {name}");
            Printer($"Der Username ist : {name} \nUnd ihr Passwort ist : {password}");            
        }

        public void PrintAllUsers (List<User> StoredUsers)
        {
            if(StoredUsers != null && StoredUsers.Count > 0)
            {
                foreach (User user in StoredUsers)
                {
                    Console.WriteLine($"Username : {user.GetUserName()}, Passwort : {user.GetPassword()} ");
                }
            }
            else
            {
                Printer("Es existiert kein User mit diesem Namen");
            }
        }

        public void EnumListPrint (List<User> options)
        {
            foreach(Enum option in Enum.GetValues(options.GetType()))
            {
                Console.WriteLine(option.ToString());
            }
        }

    }
}
