using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public abstract class Date_Decorator: IDate_Printer
    {
        protected IDate_Printer date_Printer;
        public Date_Decorator(IDate_Printer printer) { 
            this.date_Printer = printer;    
        }

        public virtual string Print() {
            return date_Printer.Print();
        }
    }
}
