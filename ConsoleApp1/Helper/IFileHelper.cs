using ConsoleApp1.LoginApp.UserMethoden.UserInformation;


namespace ConsoleApp1.Helper
{
    public interface IFileHelper
    {
        void WriteUserEntry(User users, string path);
        void WriteObjectToJson<T>(T obj, string path) where T : class;
    }
}
