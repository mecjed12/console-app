using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoginApp.Tools
{
    public interface IWeatherClient
    {
        Task RunAsync();
    }
}
