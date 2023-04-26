using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;
using Newtonsoft.Json;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.Helper
{
    public class ConsoleHelper : IConsoleHelper
    {
        public void Printer(string output) => Console.WriteLine(output);

        public int IntConvertor_String(string number) => Convert.ToInt32(number);

        public int IntConvertor_Int(int number) => Convert.ToInt32(number);

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public string ReadInput() => Console.ReadLine();

        public void PrintTheUser(string name, int password)
        {
            Printer($"Willkomen : {name}");
            Printer($"Der Username ist : {name} \nUnd ihr Passwort ist : {password}");
        }

        public void PrintAllUsers(string folderPath)
        {
            string[] userFiles = Directory.GetFiles(folderPath, "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<User>(File.ReadAllText(userFile))).ToList();


            if (users.Count > 0)
            {
                 users.ForEach(user => Console.WriteLine($"Username : {user.Name}, Passwort : {user.Password} "));
            }
            else
            {
                Printer("Es existiert kein User mit diesem Namen");
            }
        }

        public void EnumListPrint(List<User> options)
        {
            foreach (Enum option in Enum.GetValues(options.GetType()))
            {
                Console.WriteLine(option.ToString());
            }
        }
    }
}
