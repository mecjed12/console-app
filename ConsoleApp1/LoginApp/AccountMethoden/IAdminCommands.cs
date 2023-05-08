namespace ConsoleApp1.LoginApp.AccountMethoden
{
    public interface IAdminCommands
    {
        void DeleteAllUserFunction(Func<string> folderPath);
        void ChangeLogData(Func<string> folderPath);
        Task ChangeLginDataInDatabase();
        void DeleteUserOrAdminFunction(Func<string> chooseFolderPath);
        Task DeleteUserOrAdminInDataBase();
        Task DeleteAllUsersFromDataBase();
    }
}
