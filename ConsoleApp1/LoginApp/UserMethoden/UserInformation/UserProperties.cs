namespace ConsoleApp1.LoginApp.UserMethoden.UserInformation
{
    public class UserProperties
    {
        public string Username { get; set; }
        public long Password { get; set; }

        public UserProperties(string username, long password)
        {
            Username = username;
            Password = password;
        }
    }
}
