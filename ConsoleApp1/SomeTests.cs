

namespace ConsoleApp1
{
    public static class SomeTests
    {
        public static void SomeExamples()
        {
            //User obj = new User();
            //CheckUserName(Environment.UserName);
            //CheckUserName(obj.Username);
            //CheckUserName(obj);
        }



        public static bool CheckUserName1()
        {
            return Environment.UserName == "MyUser" ? true : false;
        }

        public static bool CheckUserName2()
        {
            return Environment.UserName == "MyUser";
        }

        public static bool CheckUserName6()
        {
            var userName = Environment.UserName;

            if (userName == null)
            {
                userName = "defaultUser";
            }

            if (userName == "MyUser")
            {
                return true;
            }

            return false;
        }


        //public static bool CheckUserName(string username)
        //{
        //    var userName = username ?? "defaultUser";

        //    username ??= "defaultUser";

        //    if (userName == "defaultUser")
        //    {
        //        return true;
        //    }

        //    return false;
        //}
        //public static bool CheckUserName(User user)
        //{
        //    if (user == null)
        //    {
        //        return false;
        //    }

        //    if (user.Username?.Any() == true)
        //    {
        //        return false;
        //    }

        //    user.Username ??= "defaultUser";

        //    if (user.Username == null)
        //    {
        //        user.Username = "defaultUser";
        //    }


        //    return false;
        //}
       

     }
} 

