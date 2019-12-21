using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Windows.Documents;

namespace Sakov.laba5
{
    interface IMovable
    {
        void Move();
        void DoClone();
    }
    public abstract class Tennis
    {
        public string Place;
        public string NamePlayers;
        public int PubPeople;
        public int NumberPlayes;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Tennis m = obj as Tennis;
            if (m as Tennis == null)
                return false;
            return m.Place == this.Place
                && m.NamePlayers == this.NamePlayers
                && m.PubPeople == this.PubPeople
                && m.NumberPlayes == this.NumberPlayes;
        }
        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(NamePlayers) ? 0 : NamePlayers.GetHashCode();
            hash = (hash * 47) + NumberPlayes.GetHashCode();
            return hash;
        }
        public string Vivod()
        {
            return "\n место " + Place + "\n имена игроков " + NamePlayers + "\n публика " + PubPeople + "\n номер игры " + NumberPlayes;
        }
    }
    public abstract class Things
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }

        public Things(string name,int count, int cost)
        {
            Name = name;
            Count = count;
            Cost = cost;
        }
        public void Display()
        {
            Console.WriteLine(Name);

        }

        public abstract void DoClone();
    }
    public partial class Inventory : Things, IMovable
    {

        public int CountThings;
        public string Location;
        public int TimeUsing;
        public Inventory(string name,int count, int cost)
                    : base(name, count, cost)
        {
            Name = name;
        }
        public class Printer : Inventory
        {
            public Printer(string name, int count, int cost)
            : base(name, count, cost)
            {
                Name = name;
            }
            public override void IAmPrinting(Things obj1)
            {
                Console.WriteLine(obj1.ToString());
            }
        }

        public virtual void IAmPrinting(Things obj1)
        {
            Console.WriteLine(obj1.ToString());
        }
        public void Move()
        {
            Console.WriteLine("инвентарь переместили");
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"\n количество:{CountThings}\n место нахождение:{Location}\n время использования:{TimeUsing}");
        }
        public override void DoClone()
        {
            Console.WriteLine("дарова");
        }
        void IMovable.DoClone()
        {
            Console.WriteLine("привет");
        }
    }
    public class Bench : Inventory
        {
            public int Length;
            public int Width;
            public string Material;

            public Bench(int lenght, int width, string material, string name,int count, int cost)
                : base(name,count, cost)
            {
                Length = lenght;
                Width = width;
                Material = material;
                Name = name;
                Cost = cost;
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "длина: " + Length + "\nширина: " + Width + "\nматериал: " + Material + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n";
        }
        }
        public sealed class Bars : Inventory
        {
            public int Length;
            public int Width;
            public string Material;
            public string View;


            public Bars(int lenght, int width, string material, string view, string name, int count, int cost)
                : base(name,count, cost)
            {
                Length = lenght;
                Width = width;
                Material = material;
                View = view;
                Name = name;
                Cost = cost;
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "длина: " + Length + "\nширина: " + Width + "\nматериал: " + Material + "\nвид: " + View + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n";
        }
        }
        public class Ball : Inventory
        {
            public int Size;
            public string Elastic;//упругость
            public string Material;
            public string Strength;//прочность
            public int Number;

            public Ball(int size, string elastic, string material, string strength, int number, string name, int count, int cost)
                : base(name, count, cost)
            {
                Size = size;
                Elastic = elastic;
                Material = material;
                Strength = strength;
                Name = name;
                Number = number;
                Cost = cost;
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Ball m = obj as Ball;
                if (m as Ball == null)
                    return false;
                return m.Size == this.Size
                    && m.Elastic == this.Elastic
                    && m.Material == this.Material
                    && m.Strength == this.Strength;
            }
            public override int GetHashCode()
            {
                int hash = 269;
                hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
                hash = (hash * 47) + Number.GetHashCode();
                return hash;
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "размер: " + Size + "\nупругость: " + Elastic + "\nматериал: " + Material + "\nпрочность: " + Strength + "\nномер: " + Number + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n";
        }
        }
        public class Mats : Inventory
        {
            public int Length;
            public int Width;
            public string Material;
            public string Softness;//мягкость

            public Mats(int lenght, int width, string material, string softness, string name, int count, int cost)
                : base(name, count,cost)
            {
                Length = lenght;
                Width = width;
                Material = material;
                Softness = softness;
                Name = name;
                Cost = cost;
            }
            public override void GetInfo()
            {
                Console.WriteLine($"\n количество:{CountThings}\n место нахождение:{Location}\n время использования:{TimeUsing}");
                Console.WriteLine("\n размер " + Length + "\n упругость " + Width + "\n материал " + Material + "\n прочность " + Softness + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n");
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "размер " + Length + "\n упругость " + Width + "\n материал " + Material + "\n прочность " + Softness + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n";
        }

        }
        public class Basketball : Inventory
        {
            public int Size;
            public string Elastic;//упругость
            public string Material;
            public string Strength;//прочность

            public Basketball(int size, string elastic, string material, string strength, string name, int count, int cost)
                : base(name, count, cost)
            {
                Size = size;
                Elastic = elastic;
                Material = material;
                Strength = strength;
                Name = name;
                Cost = cost;
            }
            public override void GetInfo()
            {
                Console.WriteLine($"{CountThings}{Location}{TimeUsing}");
                Console.WriteLine("\n размер " + Size + "\n упругость " + Elastic + "\n материал " + Material + "\n прочность " + Strength + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n");
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "размер " + Size + "\n упругость " + Elastic + "\n материал " + Material + "\n прочность " + Strength + "\nназвание: " + Name + "\nкол-во: " + Count + "\nцена: " + Cost + "\n";
            }
        }

    struct User
    {
        public string name;
        public int Cost;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {Cost}");
        }
    }

    public class ComputerContainer
    {
        public int counter { get; set; }
        private List<Things> list { get; set; }
        public List<Things> getThings()
        {
            return list;
        }
        public int Counter()
        {
            return counter;
        }
        public int Cost(int i)
        {

            return list[i].Cost;
        }
        public ComputerContainer()
        {
            list = new List<Things>();
        }
        public void AddThings(Things things)
        {
            list.Add(things);
            counter++;
        }
        public void PrintInfo()
        {
            for (Int32 i=0;i< counter;i++ )
                Console.WriteLine(list[i].ToString());
        }
        public void DeleteObj(Things things)
        {
                list.Remove(things);
            counter--;
        }
    }
    public class ComputerController
    {
        private ComputerContainer container;

        public ComputerController(ComputerContainer container)
        {
            this.container = container;
        }

        public void FindOfMoney()
        {
            for (Int32 i = 0; i < container.Counter(); i++)
                if (container.Cost(i) < 60 && container.Cost(i) > 30)
                    Console.WriteLine(container.getThings()[i].ToString());
        }
        public void SortThings()
        {
            List<Things> somy = new List<Things>();
            somy.Add(null);
            for (Int32 i = 0; i < container.Counter(); i++)
            {
                for (Int32 j = 0; j < container.Counter(); j++)
                {
                    if (container.getThings()[j].Count < container.getThings()[i].Count)
                    {
                        somy[0] = container.getThings()[i];
                        container.getThings()[i] = container.getThings()[j];
                        container.getThings()[j] = somy[0];
                    }
                }
            }

        }
    }
    enum INVEN
    {
        Ball=1, Bench, Bars, Mats, Basketball
    }
    class Program
    {
        static void Action(IMovable movable)
        {
            movable.Move();
        }
        static void Main(string[] args)
        {
;
            int op = (int)INVEN.Ball;
            Console.WriteLine(op); // Add

            Console.ReadLine();
            Ball ball1 = new Ball(10, "неплохой", "резина", "надёжный", 36642, "Ballich", (int)INVEN.Ball, 15);
            Console.WriteLine(ball1.ToString());
            ball1.DoClone();
            ((IMovable)ball1).DoClone();//привел к типу
            Bench bench1 = new Bench(120, 10, "дерево", "безымянная", (int)INVEN.Bench, 50);
            Bars bar1 = new Bars(70, 30, "железо", "спортивный", "Z41Bwt4", (int)INVEN.Bars, 70);
            Mats mat1 = new Mats(200, 60, "пух", "отдыхабельно", "Спортивный", (int)INVEN.Mats, 40);
            Basketball basketball1 = new Basketball(10, "неплохой", "резина", "надёжный", "Мяч", (int)INVEN.Basketball, 25);


            if (bench1 is Things)
            {
                Things bench2 = bench1;
                Console.WriteLine(bench2.ToString());
                bench2.Display();
            }
            Console.WriteLine(bar1.ToString());
            basketball1.Move();
            Console.WriteLine();
            Things ball2 = ball1;
            Things bench3 = bench1;
            Things bar2 = bar1;
            Things mat2 = mat1;
            Things basketball2 = basketball1;
            //Inventory[] arr1 = { ball1, bench1, bar1, mat1, basketball1 };
            //Things[] arr2 = { ball2, bench3, bar2, mat2, basketball2 };

            //for (Int32 i = 0; i < arr1.Length; i++)
            //{
            //    arr1[i].IAmPrinting(arr2[i]);
            //}
            ComputerContainer things = new ComputerContainer();
            things.AddThings(ball1);
            things.AddThings(bench1);
            things.AddThings(bar1);
            things.AddThings(mat1);
            things.AddThings(basketball1);
            things.PrintInfo();
            ComputerController controller = new ComputerController(things);
            Console.WriteLine("поиск предметов по диапозону цены");
            controller.FindOfMoney();
            Console.WriteLine("Сортировка по количеству");
            controller.SortThings();
            things.PrintInfo();
        }
    }
}

