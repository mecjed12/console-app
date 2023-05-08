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
            _consoleHelper.Printer("Create a Todolist: 1\n Delete a Todolist: 2\n Print all Todolists: 3\n Adding a Task to a List: 4\n Set a task to completed: 5");
            var key = _consoleHelper.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    await CreateAListAsync();
                    break;
                case ConsoleKey.D2:
                    await DeleteToDoListAsync();
                    break;
                case ConsoleKey.D3:
                    await _consoleHelper.PrintAllToDoListsFromDataBase();
                    break;
                case ConsoleKey.D4:
                    await AddingATaskAsync();
                    break;
                case ConsoleKey.D5:
                    await CompletedATaskAsync();
                    break;
                default:
                    _consoleHelper.Printer("The input is not valid");
                    break;
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

        private async Task DeleteToDoListAsync()
        {
            await _consoleHelper.PrintAllToDoListsFromDataBase();
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

        public async Task CompletedATaskAsync()
        {
            _consoleHelper.Printer("Choose a listId ");
            await _consoleHelper.PrintAllToDoListsFromDataBase();
            var id = _consoleHelper.IntConvertor_String( _consoleHelper.ReadInput());
            var listId = await _loginDataContext.ToDoList.SingleOrDefaultAsync(o => o.ListId == id);
            if (listId != null)
            {
                await _consoleHelper.PrintAllItemsOfToDoList(listId);

                _consoleHelper.Printer("Choose a TaskId to complete");
                var taskId = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                var taskcomplete = listId.Items.FirstOrDefault(o => o.ItemId == taskId);

                if(taskcomplete != null)
                {
                    taskcomplete.Completed = true;
                    await _loginDataContext.SaveChangesAsync();
                    _consoleHelper.Printer("Task complete");
                }
                else
                {
                    _consoleHelper.Printer($"Task with ID: {taskId} does not exist");
                }
            }
            else 
            {
                _consoleHelper.Printer($"This List whith ID: {id} is not exsist");
            }
        }

        public async Task AddingATaskAsync()
        {
            _consoleHelper.Printer($"Choose with the ID wich list will you adding a task:");
            await _consoleHelper.PrintAllToDoListsFromDataBase();
            var id = _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
            var listId = await _loginDataContext.ToDoList.SingleOrDefaultAsync(o => o.ListId == id);
            if (listId != null)
            {
                 while (true) 
                 {
                    _consoleHelper.Printer("Write the assignments");
                    var inputToList = _consoleHelper.ReadInput();
                    if (!string.IsNullOrEmpty(inputToList))
                    {
                        var toDoItem = new ToDoItem { Task = inputToList, CreatedAt = DateTime.UtcNow};
                        listId.Items ??= new List<ToDoItem>();
                        listId.Items.Add(toDoItem);
                    }
                    else
                    {
                        break;
                    }

                    _consoleHelper.Printer("append new assigments? Y/N");
                    var countineKey = _consoleHelper.ReadKey();

                    if (countineKey.Key == ConsoleKey.N)
                    {
                        break;
                    }
                 }

                _loginDataContext.ToDoList.Update(listId);
                await _loginDataContext.SaveChangesAsync();
            }
        }
    }
}
