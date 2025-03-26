using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Suff_Decorator:Date_Decorator
    {
        private string date_suff;
        public Suff_Decorator(IDate_Printer printer, string pref) : base(printer) //кидаем printer в базовый класс от которого пошли
        {
            this.date_suff = pref;
        }

        public override string Print()
        {
            return date_Printer.Print() + date_suff;
        }
    }
}
