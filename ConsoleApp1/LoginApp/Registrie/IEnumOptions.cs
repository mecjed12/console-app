using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoginApp.Registrie
{
    public interface IEnumOptions
    {
        void AllOptionsPrinter<TEnum>() where TEnum : Enum;
    }
}
