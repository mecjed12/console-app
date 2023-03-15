namespace ConsoleApp1.LoginApp.UserMethoden.UserInformation
{
    public class User
    {
        private UserProperties UserProperties { get;  }

        public User(UserProperties userProperties)
        {
            UserProperties = userProperties;
        }

        public User(string user, long password)
        {
            UserProperties = new UserProperties(user, password);
        }

        public long GetPassword()
        {
            return UserProperties.Password;
        }
        public string GetUserName()
        {
            return UserProperties.Username;
        }
    }
}
