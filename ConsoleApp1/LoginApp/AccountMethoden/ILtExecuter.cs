﻿
namespace ConsoleApp1.LoginApp.UserMethoden
{
    public interface ILtExecuter
    {
        bool CheckYesNoInput(bool examination);
        void InitializeStart(string[] args);
        Task LoginCase();
    }
}
