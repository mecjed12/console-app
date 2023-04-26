using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Config
{
    public interface IAppSettings
    {
        string UsersFolderPath { get; set; }
        string AdminFolderPath { get; set; }

    }
}
