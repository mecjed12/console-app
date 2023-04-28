using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoginApp.AccountMethoden.UserInformation
{
    public class Users
    {
        private Guid _guid;

        public Users() 
        {
            _guid = Guid.NewGuid();
        }

        public string Id => _guid.ToString();
        public string Name {  get; set; }
        public long Password { get; set; }
        public DateTime CreationAt { get; set; }
    }
}
