using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.lab3
{
    public partial class Bus
    {
        private static int count = 0;
        private static int people;
        private string NameBus;
        private string Driver;
        private int NumberBus;
        private int NumberWay;
        private string TypeBus;
        private int BegingBusYear;
        private int RunBus;
        private const int Seats = 64;
        public readonly double K = 23;
        public Bus() //без параметров
        {
            NameBus = "";
            Driver = "";
            NumberBus =0;
            NumberWay =0;
            TypeBus = "";
            BegingBusYear=0;
            RunBus =0;
        }
        public Bus(string a, string b, int c, int d, string i, int f, int g, int e)//с параметрами
        {
            NameBus = a;
            Driver = b;
            NumberBus = c;
            NumberWay = d;
            TypeBus = i;
            BegingBusYear = f;
            RunBus = g;
            ValuePeople = e;
        }
        static Bus()//статический
        {
            count++;
            people = 45;
        }
        public string Line { get; set; }//автоматические свойства
        public int Age { get; set; }
        public int ValuePeople//свойства в ручную
        {
            set
            {
                if (value < Seats || value > 1)
                    people = value;
                else
                    Console.WriteLine("невозможное значение пассажиров");
            }
            get
            {
                return people;
            }
        }
        public int FuncRef(int people, ref int RunBus)//метод с использованием ref
        {
            if (people < Seats || people > 1)
            {
                RunBus = RunBus - people;
                return RunBus;
            }
            else
            {
                throw new FormatException();
            }
        }
        public int FuncOut(int people, out int seats)//метод с использованием out
        {
            if (people < Seats || people > 1)
            {
                seats = people;
                return seats;
            }
            else
                throw new FormatException();
        }
        static void GetInfo(Bus obj)
        {
            Console.WriteLine(" кол-во стат констр " + count + "\n"
                + " назв автробуса " + obj.NameBus + "\n"
                + " водитель " + obj.Driver + "\n"
                + " номер автобуса " + obj.NumberBus + "\n"
                + " номер пути " + obj.NumberWay + "\n"
                + " тип автобуса " + obj.TypeBus + "\n"
                + " начало исп. " + obj.BegingBusYear + "\n"
                + " пробег " + obj.RunBus + "\n"
                + " кол-во людей " + people + "\n");
        }
        static void Main(string[] args)
        {
            try
            {
                Bus stat = new Bus();
                GetInfo(stat);
                Bus number1 = new Bus("HardRace", "Ujin",4645, 666, "Hard", 2004, 200000, 60);
                GetInfo(number1);
                int seats = 64;
                number1.FuncOut(people, out seats);

                Bus number2 = new Bus("EasyRace", "Zhenya",12456,111,"Easy",2000,300000,45);
                GetInfo(number2);
                number2.FuncRef(people, ref number2.RunBus);

                Console.WriteLine(number1.Equals(number1));
                Console.WriteLine(number1.Equals(number2));
                Console.WriteLine(number1.GetHashCode());
                Console.WriteLine(number1.ToString());

                Bus number3 = new Bus("Plaisy", "Misha", 156, 456, "Easy", 2012, 200000, 37);
                Bus number4 = new Bus("Lagun", "Alex", 5686, 111, "Medium", 2009, 200000, 14);
                Bus number5 = new Bus("BOOMTOUR", "Katya", 1356, 456, "Easy", 1999, 250000, 63);
                Bus[] arr = new Bus[] { number1, number2, number3, number4, number5 };
                for(int i =0;i< arr.Length;i++)
                {
                    if(arr[i].NumberWay==456)
                        GetInfo(arr[i]);
                }
                int use = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < arr.Length; i++)
                {
                    if (2019-arr[i].BegingBusYear > use)
                        GetInfo(arr[i]);
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("у вас невозможное значение пассажиров");
            }

        }
    }

}
