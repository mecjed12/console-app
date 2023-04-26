using ConsoleApp1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Config
{
    public class AppSettings : IAppSettings
    {
        public string UsersFolderPath { get; set; }
        public string AdminFolderPath { get; set; }
        
    }
}
