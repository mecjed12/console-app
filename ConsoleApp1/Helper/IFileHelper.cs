﻿using ConsoleApp1.LoginApp.AccountMethoden.UserInformation;
using LoginAppData;

namespace ConsoleApp1.Helper
{
    public interface IFileHelper
    {
        void WriteUserEntry(Account users, string path);
        void WriteObjectToJson<T>(T obj, string path) where T : class;
        void WriteNewDataInTheJsonFile(string message, Users selectedUser, int selectedIndex, string[] userFiles);
    }
}
