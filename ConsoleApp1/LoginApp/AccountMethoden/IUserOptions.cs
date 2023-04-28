using ConsoleApp1.LoginApp.Registrie;
using SharedLibary;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface IUserOptions
    {
        Options OptionSelector();
        UsersOptions AccountsOptions();
        Adminrights AdminCommands();
    }
}
