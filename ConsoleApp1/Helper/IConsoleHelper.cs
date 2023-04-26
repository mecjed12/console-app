using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.Helper
{
    public interface IConsoleHelper
    {
        void Printer(string message);
        int IntConvertor_String(string number);
        int IntConvertor_Int(int number);
        string ReadInput();
        void PrintTheUser(string name, int password);
        void PrintAllUsers(string folderPath);
        void EnumListPrint(List<User> options);
        ConsoleKeyInfo ReadKey();

    }
}
