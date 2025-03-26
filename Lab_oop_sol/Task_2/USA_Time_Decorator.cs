using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class USA_Time_Decorator:IDate_Printer
    {
        public string Print()
        {
            return DateTime.Now.ToString(new CultureInfo("en-Us")); //это нынешнее время
        }
    }
}
