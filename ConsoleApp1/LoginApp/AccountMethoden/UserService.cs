﻿using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Tools;
using Newtonsoft.Json;
using ConsoleApp1.Config;
using LoginAppData;
using Microsoft.EntityFrameworkCore;
using static ConsoleApp1.LoginApp.Registrie.EnumOptions;
using SharedLibary;

namespace ConsoleApp1.LoginApp.UserMethoden
{
    public class UserService : IUserService
    {
        private readonly ILoginDataContext _loginDataContext;
        private readonly IRegistring _registring;
        private readonly IConsoleHelper _consoleHelper;
        private readonly IWeatherClient _weatherClient;
        private readonly IFileHelper _fileHelper;
        public readonly IAppSettings _settings;

        public UserService(IRegistring registring, IConsoleHelper consoleHelper, IWeatherClient weatherClient,IFileHelper fileHelper,IAppSettings settings,ILoginDataContext loginDataContext)
        {
            _registring = registring;
            _consoleHelper = consoleHelper;
            _weatherClient = weatherClient;
            _fileHelper = fileHelper;
            _settings = settings;
            _loginDataContext = loginDataContext;
        }

        public async Task CreateUser(UsersOptions usersOptions)
        {
            try
            {
                var userName = _registring.RegistryName();
                var password = _registring.RegistryPassword();
                _consoleHelper.Printer("Sie haben sich erfolgreich registriert");
                var adminCondition = (usersOptions == UsersOptions.Admin);
                var newAccount = new Account
                {
                    Name = userName,
                    Password = password,
                    CreatedAt = DateTime.UtcNow.AddHours(1),
                    AccountType = adminCondition,
                }; 
                await SaveAccountToDatabaseAsync(newAccount);
            }
            catch(DbUpdateException ex)
            {
                _consoleHelper.Printer("Fehler beim speichern Des Users auf der Datenbank");
                _consoleHelper.Printer(ex.InnerException?.Message ??ex.Message);
            }
        }

        public async Task SaveAccountToDatabaseAsync(Account newAccount)
        {
            _loginDataContext.Accounts.Add(newAccount);
            await _loginDataContext.SaveChangesAsync();
        }

        public async Task<bool> LoginUser()
        {
            _consoleHelper.Printer("Bitte geben Sie ihren Username ein");
            var user = await FindUser();
            if (user == null )
            {
                return false;
            }

            return await PasswordCheckOver(user);
        }

        public async Task<Account?> FindUser()
        {
            string requestedUserName = _consoleHelper.ReadInput();
            var userFiles = await _loginDataContext.Accounts
                .FirstOrDefaultAsync(account => account.Name == requestedUserName);
            if (userFiles == null)
            {
                _consoleHelper.Printer("Dieser User exestiert nicht");
            }
            return userFiles;
        }


        public Task<bool> PasswordCheckOver(Account account)
        {
            _consoleHelper.Printer("Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var password =  _consoleHelper.IntConvertor_String(_consoleHelper.ReadInput());
                    var convertetPassword = _consoleHelper.LongConverterInt(password);
                    if (convertetPassword == account.Password)
                    {
                        _consoleHelper.Printer("Sie haben sich erflogreich Angemeldet");
                        return Task.FromResult(true);
                    }
                    else
                    {
                        _consoleHelper.Printer($"Sie haben das Passwort falsch eingegben bitte geben sie es erneut ein ");
                        _consoleHelper.Printer($"Sie haben noch {3 - i} versuche");
                    }
                }
                catch
                {
                    throw new FormatException("Bitte geben Sie NUmmer ein");
                }
            }
            _consoleHelper.Printer("Anmeldung fehlgeschlagen");
            return Task.FromResult(false);
        }

        public bool SwitchToServices()
        {
            _consoleHelper.Printer("Wollen Sie den Service benutzen Y/N");
            ConsoleKeyInfo choiceServicesOrNot = _consoleHelper.ReadKey();
            if(choiceServicesOrNot.Key == ConsoleKey.Y)
            {
                _consoleHelper.Printer("Wollen Sie das Wetter ausgeben oder den Agenten aktivieren: Wetter/W , Agent/A");
                ConsoleKeyInfo choiceAgentOrWeather = _consoleHelper.ReadKey();
                if (choiceAgentOrWeather.Key == ConsoleKey.W)
                {
                    _weatherClient.RunAsync();
                }
                else if(choiceAgentOrWeather.Key == ConsoleKey.A)
                {
                }
            
            }
            else if (choiceServicesOrNot.Key == ConsoleKey.N)
            {
                return false;
            }
            return true;
        }

        public string ChooseFolderPath()
        {
            _consoleHelper.Printer("Admin oder User wählen");
            var folderPath = _consoleHelper.ReadInput();

            return folderPath == "Admin" ? _settings.AdminFolderPath :
                   folderPath == "User" ? _settings.UsersFolderPath : 
                   null;
        }
    }
}
