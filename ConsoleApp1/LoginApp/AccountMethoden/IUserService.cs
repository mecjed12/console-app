using ConsoleApp1.LoginApp.UserMethoden.UserInformation;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserService
    {
        void CreateUser(string path);
        bool LoginUser(string folderPath);
        User FindUser(string folderPath);
        bool SwitchToServices();
    }
}
