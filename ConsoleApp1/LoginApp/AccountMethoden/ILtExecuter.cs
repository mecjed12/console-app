
namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface ILtExecuter
    {
        Task<bool> CheckYesNoInput(bool examination);
        void InitializeStart(string[] args);
    }
}
