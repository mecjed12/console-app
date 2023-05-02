using ConsoleApp1.LoginApp.AccountMethoden.UserInformation;
using ConsoleApp1.LoginApp.Registrie;
using LoginAppData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.Helper
{
    public class ConsoleHelper : IConsoleHelper
    {
        private readonly ILoginDataContext _loginDataContext;

        public ConsoleHelper (ILoginDataContext loginDataContext)
        {
            _loginDataContext = loginDataContext;
        }

        public void Printer(string message) => Console.WriteLine(message);

        public int IntConvertor_String(string number) => Convert.ToInt32(number);

        public long LongConverterInt(int number) => Convert.ToInt64(number);

        public long LongConverterString(string number) => Convert.ToInt64(number);

        public int IntConvertor_Int(int number) => Convert.ToInt32(number);

        public ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public string ReadInput() => Console.ReadLine();

        public void PrintTheUser(string name, int password)
        {
            Printer($"Willkomen : {name}");
            Printer($"Der Username ist : {name} \nUnd ihr Passwort ist : {password}");
        }

        public void PrintAllUsersFromJsonFIles(Func<string> folderPath)
        {
            string[] userFiles = Directory.GetFiles(folderPath(), "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<Users>(File.ReadAllText(userFile))).ToList();
            if (users.Count > 0)
            {
                 users.ForEach(user => Console.WriteLine($"Username : {user?.Name}, Passwort : {user?.Password} "));
            }
            else
            {
                Printer("Es existiert kein User mit diesem Namen");
            }
        }

        public async Task PrintAllUsersFromDataBase(string accountype)
        {
            if(accountype == "User")
            {
                var users = await _loginDataContext.Accounts
                        .Where(o => o.AccountType == false)
                        .ToListAsync();
                foreach (var user in users)
                {
                    Printer($"Id: {user.Id} , Username: {user.Name}, AccountRights: User");
                }
            }
            else if(accountype == "Admin")
            {
                var users = await _loginDataContext.Accounts
                        .Where(o => o.Id != 0)
                        .ToListAsync();
                foreach (var user in users)
                {
                    var accountRightsCheck = (user.AccountType) ? "Admin" : "User";
                    Printer($"Id: {user.Id} , Username: {user.Name} , Password: {user.Password},  AccountRights: {accountRightsCheck}");
                }
            }
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

        public void PrintTheToDoList(List<string> toDoList)
        {
            DateTime currrentDate = DateTime.Now;
            string formattedDate = currrentDate.ToString("dddd - MMMM dd, yyyy");
            Printer(formattedDate);

            for(int i = 0;i < toDoList.Count; i++)
            {
                Printer($"{i + 1}: {toDoList[i]}");
            }
        }

        public async Task PrintAllToDoListFromDataBase()
        {
            var lists = await _loginDataContext.ToDoList
                        .Where(o => o.ListId > 0)
                        .ToListAsync ();

            foreach (var list in lists)
            {
                Printer($" Id: {list.ListId} , Name: {list.ListName}");
            }
        }
    }
}
