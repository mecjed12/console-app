namespace ConsoleApp1.LoginApp.UserMethoden.UserInformation
{
    public class UserProperties
    {
        public string Username { get; set; }
        public int Password { get; set; }

        public UserProperties(string username, int password)
        {
            Username = username;
            Password = password;
        }
    }
}
