using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserService
    {
        void CreateUser(List<User> usersList);
        bool LoginUser(List<User> usersList);
        User FindUser(List<User> usersList);
        bool SwitchToServices();
    }
}
