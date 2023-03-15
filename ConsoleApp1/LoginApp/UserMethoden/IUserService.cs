using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserService
    {
        void CreateUser(List<User> users);
        bool LoginUser(List<User> users);
        User FindUser(List<User> users);
    }
}
