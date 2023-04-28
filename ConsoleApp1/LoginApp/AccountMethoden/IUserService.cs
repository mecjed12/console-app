using SharedLibary;
using LoginAppData; 

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserService
    {
        Task CreateUser(UsersOptions usersOptions);
        Task<bool> LoginUser();
        Task<Account?> FindUser();
        bool SwitchToServices();
        string ChooseFolderPath(bool options);
        Task SaveAccountToDatabaseAsync(Account newAccount);
    }
}
