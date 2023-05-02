
namespace ConsoleApp1.Helper
{
    public interface IConsoleHelper
    {
        void Printer(string message);
        int IntConvertor_String(string number);
        int IntConvertor_Int(int number);
        long LongConverterInt(int number);
        long LongConverterString(string number);
        string ReadInput();
        void PrintAllUsersFromJsonFIles(Func<string> folderPath);
        Task PrintAllUsersFromDataBase(string accountype);
        ConsoleKeyInfo ReadKey();
        void AllOptionsPrinter<TEnum>() where TEnum : Enum;
        void PrintTheToDoList(List<string> toDoList);
        Task PrintAllToDoListFromDataBase();
    }
}
