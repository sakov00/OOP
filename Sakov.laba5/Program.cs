using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Things(string name)
        {
            Name = name;
        }
        public void Display()
        {
            Console.WriteLine(Name);

        }

        public abstract void DoClone();
    }
    public class Inventory : Things, IMovable
    {

        public int CountThings;
        public string Location;
        public int TimeUsing;
        public Inventory(string name)
                    : base(name)
        {
            Name = name;
        }
        public class Bench : Inventory
        {
            public int Length;
            public int Width;
            public string Material;

            public Bench(int lenght, int width, string material, string name)
                : base(name)
            {
                Length = lenght;
                Width = width;
                Material = material;
                Name = name;
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "длина: " + Length + "\nширина: " + Width + "\nматериал: " + Material + "\nназвание: " + Name+ "\n";
            }
        }
        public sealed class Bars : Inventory
        {
            public int Length;
            public int Width;
            public string Material;
            public string View;


            public Bars(int lenght, int width, string material, string view, string name)
                : base(name)
            {
                Length = lenght;
                Width = width;
                Material = material;
                View = view;
                Name = name;
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "длина: " + Length + "\nширина: " + Width + "\nматериал: " + Material + "\nвид: " + View + "\nназвание: " + Name+ "\n";
            }
        }
        public class Ball : Inventory
        {
            public int Size;
            public string Elastic;//упругость
            public string Material;
            public string Strength;//прочность
            public int Number;

            public Ball(int size, string elastic, string material, string strength, int number, string name)
                : base(name)
            {
                Size = size;
                Elastic = elastic;
                Material = material;
                Strength = strength;
                Name = name;
                Number = number;
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
                return "размер: " + Size + "\nупругость: " + Elastic + "\nматериал: " + Material + "\nпрочность: " + Strength + "\nномер: " + Number + "\nназвание: " + Name+ "\n";
            }
        }
        public class Mats : Inventory
        {
            public int Length;
            public int Width;
            public string Material;
            public string Softness;//мягкость

            public Mats(int lenght, int width, string material, string softness,string name)
                :base(name)
            {
                Length = lenght;
                Width = width;
                Material = material;
                Softness = softness;
                Name = name;
            }
            public override void GetInfo()
            {
                Console.WriteLine($"\n количество:{CountThings}\n место нахождение:{Location}\n время использования:{TimeUsing}");
                Console.WriteLine("\n размер " + Length + "\n упругость " + Width + "\n материал " + Material + "\n прочность " + Softness + "\nназвание: " + Name);
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "размер " + Length + "\n упругость " + Width + "\n материал " + Material + "\n прочность " + Softness + "\nназвание: " + Name+ "\n";
            }

        }
        public class Basketball : Inventory
        {
            public int Size;
            public string Elastic;//упругость
            public string Material;
            public string Strength;//прочность

            public Basketball(int size, string elastic, string material, string strength, string name)
                : base(name)
            {
                Size = size;
                Elastic = elastic;
                Material = material;
                Strength = strength;
                Name = name;
            }
            public override void GetInfo()
            {
                Console.WriteLine($"{CountThings}{Location}{TimeUsing}");
                Console.WriteLine("\n размер " + Size + "\n упругость " + Elastic + "\n материал " + Material + "\n прочность " + Strength + "\nназвание: " + Name);
            }
            public override string ToString()
            {
                Console.WriteLine(GetType());
                return "размер " + Size + "\n упругость " + Elastic + "\n материал " + Material + "\n прочность " + Strength + "\nназвание: " + Name+ "\n";
            }
        }
        public class Printer : Inventory
        {
            public Printer(string name)
            : base(name)
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
    class Program
    {
        static void Main(string[] args)
        {
            Inventory.Ball ball1 = new Inventory.Ball(10,"неплохой","резина","надёжный", 36642,"Ballich");
            Console.WriteLine(ball1.ToString());
            ball1.DoClone();
            ((IMovable)ball1).DoClone();//привел к типу
            Inventory.Bench bench1 = new Inventory.Bench(120,10,"дерево","безымянная");
            Inventory.Bars bar1 = new Inventory.Bars(70,30,"железо","спортивный","Z41Bwt4");
            Inventory.Mats mat1 = new Inventory.Mats(200, 60,"пух","отдыхабельно","Спортивный");
            Inventory.Basketball basketball1 = new Inventory.Basketball(10, "неплохой", "резина", "надёжный","Мяч");

            //Tennis bench2 = new Tennis();нельзя\\

            if (bench1 is Things)
            {
                Things bench2 = (Things)bench1;
                Console.WriteLine(bench2.ToString());
                bench2.Display();
            }
            Console.WriteLine(bar1.ToString());
            basketball1.Move();
            Console.WriteLine();
            Things ball2 = ball1;
            Things bench3 =bench1;
            Things bar2 = bar1;
            Things mat2 =mat1;
            Things basketball2 =basketball1;
            Inventory[] arr1 = { ball1, bench1, bar1, mat1, basketball1 };
            Things[] arr2 = { ball2, bench3, bar2, mat2, basketball2 };

            for(Int32 i=0;i<arr1.Length;i++)
            {
                arr1[i].IAmPrinting(arr2[i]);
            }
        }
    }
}
