using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Pref_Decorator:Date_Decorator
    {
        private string date_pref;
        public Pref_Decorator(IDate_Printer printer, string pref) : base(printer) //кидаем printer в базовый класс от которого пошли
        {
            this.date_pref = pref;
        }

        public override string Print() {
            return date_pref + date_Printer.Print();
        }
    }
}
