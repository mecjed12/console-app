namespace ConsoleApp1.LoginApp.UserMethoden.UserInformation
{
    public class User
    {
        private Guid _guid;

       
        public User()
        {
            _guid = Guid.NewGuid();
        }

        public string Id => _guid.ToString();
        public string Name { get; set; }
        public long Password { get; set; }
        public DateTime CreateAt { get; set; }


    }
}
