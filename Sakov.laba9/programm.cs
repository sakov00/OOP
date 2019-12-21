using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.laba9
{
    class programm
    {
        static void Main(string[] args)
        {
            User pon1 = new User("Zhenya",67,"lol");
            User pon2 = new User("Kirill", 90,"pam");
            User pon3 = new User("Dima", 1,"teach");

            pon1.upgrade += DisplayMessage;
            pon1.work += DisplayMessage;

            Action<User> op1;
            op1 = User.Print;
            Operation(op1, pon1);
            op1.Invoke(pon2);
            op1.Invoke(pon3);

            pon1.Print1();
            pon1.Print2();
            //pon1.str = pon1.AddSymbol(pon1.str);
            //pon2.str = pon2.AddSymbol(pon2.str);

            //pon1.str = pon1.DelSymbol(pon1.str);
            //pon2.str = pon2.DelSymbol(pon2.str);

            //pon1.str = pon1.DelPrep(pon1.str);

            //pon1.str = pon1.SymbolUp(pon1.str);

            //pon1.Print2();
            Func<User,User> myFunc = User.SymbolUp;
            User.Operation(pon1);
            User.Operation(pon2);
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
        static void Operation(Action<User> op,User obj)
        {
                op(obj);
        }
    }
}
