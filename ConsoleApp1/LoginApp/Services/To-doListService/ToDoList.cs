

using ConsoleApp1.Helper;
using LoginAppData;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.LoginApp.Services.To_doListService
{
    public class ToDoList : IToDoList
    {
        private readonly IConsoleHelper _consoleHelper;
        private readonly ILoginDataContext _loginDataContext;

        public ToDoList (IConsoleHelper consoleHelper,ILoginDataContext loginDataContext)
        {
            _consoleHelper = consoleHelper;
            _loginDataContext = loginDataContext;
        }

        public async Task ToDoListCase()
        {
            _consoleHelper.Printer("Create a Todolist: C\n Delete a Todolist: D\n Print all Todolists: P");
            var key = _consoleHelper.ReadKey();
            if(key.Key == ConsoleKey.C)
            {
                await CreateAListAsync();
            }
            else if (key.Key == ConsoleKey.D)
            {
                await DeleteToDoList();
            }
            else if(key.Key == ConsoleKey.P)
            {
                await _consoleHelper.PrintAllToDoListFromDataBase();
            }
            else
            {
                _consoleHelper.Printer("The input is not valid");
            }
        }

        private async Task CreateAListAsync()
        {
            var toDoList = new ToDoListModel
            {
                Items = new List<ToDoItem>()
            };
            _consoleHelper.Printer("Name for the todolist");
            var nameForTheList = _consoleHelper.ReadInput();
            toDoList.ListName = nameForTheList;
            while (true)
            {
                _consoleHelper.Printer("Write the assignments");
                var inputToList = _consoleHelper.ReadInput();
                if(inputToList != null)
                {
                    var toDoItem = new ToDoItem { Task = inputToList, CreatedAt = DateTime.UtcNow };
                    toDoList.Items.Add(toDoItem);
                }
                else
                {
                    break;
                }

                _consoleHelper.Printer("append new assigments? Y/N");
                var countineKey = _consoleHelper.ReadKey();
                
                if(countineKey.Key == ConsoleKey.N)
                {
                    break;
                }
            }
            _loginDataContext.ToDoList.Add(toDoList);
            await _loginDataContext.SaveChangesAsync();
        }

        private async Task DeleteToDoList()
        {
            await _consoleHelper.PrintAllToDoListFromDataBase();
            _consoleHelper.Printer("Here are all Todolists\n choose the id wich to delete");
            var id = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
            var lists = await _loginDataContext.ToDoList.SingleOrDefaultAsync(o => o.ListId == id);
            if(lists == null)
            {
                _consoleHelper.Printer($"This List whith ID: {id} is not exsist");
            }
            else
            {
                _loginDataContext.ToDoList.Remove(lists);
                await _loginDataContext.SaveChangesAsync();
                _consoleHelper.Printer($"This Todolist is deleted");
            }
        }
    }
}
