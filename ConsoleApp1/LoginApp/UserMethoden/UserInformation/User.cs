namespace ConsoleApp1.LoginApp.UserMethoden.UserInformation
{
    public class User
    {
        private UserProperties _userProperties;

        public string UserName => _userProperties.Username;
        public int Password => _userProperties.Password;


        public User(UserProperties userProperties)
        {
            _userProperties = userProperties;
        }

        public User(string user, int pasasword)
        {
            _userProperties = new UserProperties(user, pasasword);
        }
    }
}
