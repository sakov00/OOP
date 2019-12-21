using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.laba12
{
    interface IMovable
    {                                          
        string Name { get; set; }   
    }
    interface IComparable
    {
        string Name { get; set; }
    }
    public class User: IMovable, IComparable
    {
        private int Years_Learning;
        public int Friends;
        public int Value_Friends;
        public string Name { get; set; }
        public int Age { get; set; }
        public User()
        {

        }
        private void Display()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
