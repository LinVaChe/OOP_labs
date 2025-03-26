using Task_2;

IDate_Printer obj_e = new Europ_Time_Decorator();

obj_e = new Pref_Decorator(obj_e, "aa ");
obj_e = new Suff_Decorator(obj_e, " bbb");

Console.WriteLine("European time: " + obj_e.Print());

IDate_Printer obj_usa = new USA_Time_Decorator();

obj_usa = new Pref_Decorator(obj_usa, "*** ");
obj_usa = new Suff_Decorator(obj_usa, " ///");

Console.WriteLine("USA time: " + obj_usa.Print());
