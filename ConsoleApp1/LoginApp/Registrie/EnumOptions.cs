namespace ConsoleApp1.LoginApp.Registrie
{
    public class EnumOptions 
    {
        public enum Options
        {
            ProgrammVerlassen = 0,
            NeuerUserRegestrieren = 1,
            Login = 2,
            OutputofAllUser = 3,
        }

        public enum Adminrights
        {
            DeleteUsersOrAdmin = 0,
            DeleteAllUsers = 1,
            OutputOfAllUsers = 2,
            ChangeLoginData = 3,
            AdminRightsExit = 4, 
        }
    }
}

