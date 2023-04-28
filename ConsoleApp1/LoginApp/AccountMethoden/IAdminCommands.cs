using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoginApp.AccountMethoden
{
    public interface IAdminCommands
    {
        void DeleteAllUserFunction(Func<string> folderPath);
        void ChangeLogData(Func<string> folderPath);
        Task ChangeLginDataInDatabase();
        void DeleteUserOrAdminFunction(Func<string> chooseFolderPath);
        Task DeleteUserOrAdminInDataBase();
        Task DeleteAllUsersFromDataBase();
    }
}
