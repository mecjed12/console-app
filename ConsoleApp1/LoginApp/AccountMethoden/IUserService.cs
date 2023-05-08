using SharedLibary;
using LoginAppData; 

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserService
    {
        Task CreateUser(UsersOptions usersOptions);
        Task<bool> LoginUser();
        Task<Account?> FindUser();
        Task<bool> CheckIfUserExists(string input);
        Task<bool> SwitchToServices();
        string ChooseFolderPath(bool options);
        Task SaveAccountToDatabaseAsync(Account newAccount);
        Task<bool> SecureWordCheckOver(Account account);
    }
}
