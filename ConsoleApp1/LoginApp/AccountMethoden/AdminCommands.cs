

using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.AccountMethoden.UserInformation;
using LoginAppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using ScottPlot.Renderable;
using System.Collections.Generic;

namespace ConsoleApp1.LoginApp.AccountMethoden
{
    public class AdminCommands : IAdminCommands
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly IFileHelper _fileHelper;
        private readonly ILoginDataContext _loginDataContext;

        public AdminCommands(IConsoleHelper consoleHelper, IFileHelper fileHelper,ILoginDataContext loginDataContext)
        {
            _consoleHelper = consoleHelper;
            _fileHelper = fileHelper;
            _loginDataContext = loginDataContext;
        }

        public void DeleteUserOrAdminFunction(Func<string> chooseFolderPath)
        {
            var index = 0;
            string[] userFiles = Directory.GetFiles(chooseFolderPath(), "*.json");
            if(userFiles.Length == 0)
            {
                _consoleHelper.Printer("There is no User");
                return;
            }
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<Users>(File.ReadAllText(userFile))).ToList();
            users.ForEach(user => _consoleHelper.Printer($"{index ++}. Username: {user.Name}, Passwort: {user.Password}"));

            _consoleHelper.Printer("Wählen Sie den User aus, den Sie löschen möchten (geben Sie die Nummer ein)");
            int selectIndex;
            if(int.TryParse(_consoleHelper.ReadInput(), out selectIndex) && selectIndex >= 0 && selectIndex < users.Count)
            { 
                var selectedFile = userFiles[selectIndex];
                File.Delete(selectedFile);
                _consoleHelper.Printer("Der User wurde gelöscht");
            }
            else
            {
                _consoleHelper.Printer("Invalid selection");
            }
        }

        public void DeleteAllUserFunction(Func<string> chooseFolderPath)
        {
            string[] userFiles = Directory.GetFiles(chooseFolderPath(), "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<Users>(File.ReadAllText(userFile))).ToList() ;
            users.ForEach(user => _consoleHelper.Printer($"Username: {user.Name}, Passwort: {user.Password}"));

            userFiles.ToList().ForEach(file => File.Delete(file));
            _consoleHelper.Printer("Alle Users sind gelöscht");
        }

        public void ChangeLogData(Func<string> chooseFolderPath)
        {
            var index = 0;
            string[] userFiles = Directory.GetFiles(chooseFolderPath(), "*.json");
            var users = userFiles.Select(userFile => JsonConvert.DeserializeObject<Users>(File.ReadAllText(userFile))).ToList();
            users.ForEach(user => _consoleHelper.Printer($"{index ++}, Username: {user.Name}, Passwort: {user.Password}"));

            _consoleHelper.Printer("Wählen Sie den User aus, den Sie LoginData ändern möchten (geben Sie die Nummer ein)");
            if (int.TryParse(_consoleHelper.ReadInput(), out int selectIndex) && selectIndex >= 0 && selectIndex < users.Count)
            {
                var selectedFile = userFiles[selectIndex];
                _consoleHelper.Printer("Auswählen was sie änder wollen Username oder Passwort");
                var loginDataChange = _consoleHelper.ReadInput();
                if (loginDataChange == "Username")
                {
                    _consoleHelper.Printer("Den neuename eingäben");
                    var newUsername = _consoleHelper.ReadInput();
                    Users selectedUser = users[selectIndex];
                    selectedUser.Name = newUsername;
                    _fileHelper.WriteNewDataInTheJsonFile("Username", selectedUser, selectIndex, userFiles);
                }
                else if (loginDataChange == "Password")
                {
                    _consoleHelper.Printer("Geben sie neue Passwort ein");
                    var newPassword = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    Users selectedUser = users[selectIndex];
                    selectedUser.Password = newPassword;
                    _fileHelper.WriteNewDataInTheJsonFile("Password", selectedUser, selectIndex, userFiles);
                }
            }
            else
            {
                _consoleHelper.Printer("Ungültige eingabe");
            }
        }

        public async Task DeleteUserOrAdminInDataBase()
        {
            await _consoleHelper.PrintAllUsersFromDataBase("Admin");
            _consoleHelper.Printer("Here are all users and Admin\n Choose the id wich to delete");
            var id = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
            var user = await _loginDataContext.Accounts.SingleOrDefaultAsync(o => o.Id == id);
            if(user == null) 
            {
                _consoleHelper.Printer($"This Userid: {id} is not exsist");
            }
            else
            {
                _loginDataContext.Accounts.Remove(user);
                await _loginDataContext.SaveChangesAsync();
                _consoleHelper.Printer($"User with ID {id} has been deleted");
            }
        }

        public async Task DeleteAllUsersFromDataBase()
        {
            _consoleHelper.Printer("Are you sure to delete all users: Y/N");
            var deleteAllUserKey = _consoleHelper.ReadKey();
            if(deleteAllUserKey.Key == ConsoleKey.Y)
            {
                var users = _loginDataContext.Accounts.Where(o => o.AccountType == false);
                _loginDataContext.Accounts.RemoveRange(users);
                await _loginDataContext.SaveChangesAsync();
            }
        }

        public async Task ChangeLginDataInDatabase()
        {
            await _consoleHelper.PrintAllUsersFromDataBase("Admin");
            var newId = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
            var account = await _loginDataContext.Accounts.SingleOrDefaultAsync(o => o.Id == newId);

            _consoleHelper.Printer("Choose the Id for wich User you will change the Data");
            if(account != null)
            {
                _consoleHelper.Printer("Wich Column wich like  to chance: Username / Password ");
                var columnPostion  = _consoleHelper.ReadInput();
                if(columnPostion == "Username")
                {
                    _consoleHelper.Printer("Input you new Username");
                    var newUserName = _consoleHelper.ReadInput();
                    account.Name = newUserName;
                }
                else if( columnPostion == "Password")
                {
                    _consoleHelper.Printer("Input you new Password");
                    var newPassword = _consoleHelper.LongConverterString(_consoleHelper.ReadInput());
                    account.Password = newPassword;
                }
                else
                {
                    _consoleHelper.Printer("Invalid input. Please try again");
                    return;
                }

                await _loginDataContext.SaveChangesAsync();
                _consoleHelper.Printer("Data updated successfully");
            }
            else
            {
                _consoleHelper.Printer("No User found with the given Id");
            }
        }
    }
}
