using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;

namespace ConsoleAppTest
{
    internal class UserSurface : LtExecuter
    {
        public UserSurface(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions) : base(consoleHelper, userService, userOptions)
        {
        }
    }
}