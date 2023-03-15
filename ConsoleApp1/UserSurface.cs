// See https://aka.ms/new-console-template for more information

using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;

internal class UserSurface : UserInterface
{
    public UserSurface(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions) : base(consoleHelper, userService, userOptions)
    {
    }
}