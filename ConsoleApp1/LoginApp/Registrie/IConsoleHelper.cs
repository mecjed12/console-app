using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.Registrie
{
    public interface IConsoleHelper
    {
        void Printer(string message);
        int IntConvertor_String(string number);
        int IntConvertor_Int(int number);
        string ReadInput();
        void PrintTheUser(string name, int password);
        void PrintAllUsers(List<User> StoredUsers);
        void EnumListPrint(List<User> options);
        ConsoleKeyInfo ReadKey();

    }
}
