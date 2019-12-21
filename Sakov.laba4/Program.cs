using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.laba4
{
    public class List
    {
        // Класс узел (один объект в списке)
        public class Node
        {
            public int Data;
            public Node Next; // ссылка на след. элемент
            //Конструктор
            public Node(int data)
            {
                Data = data;
                Next = null;

            }
        }
        public Node head;
        public Node tail;
        public int count;  // количество элементов в списке

        public class Owner
        {
            public int Id;
            public string Name;
            public string NameOrg;
            //Конструктор
            public Owner(int data, string name, string nameorg)
            {
                Id = data;
                Name = name;
                NameOrg = nameorg;
            }
            public override string ToString()
            {
                return Id + " " + Name + " " + NameOrg;
            }
        }
        public class Date
        {
            public int Year;
            public int Month;
            public int Day;

            //Конструктор
            public Date(int year, int month, int day)
            { 
            Year= year;
            Month= month;
            Day= day;
            }
            public override string ToString()
            {
                return Year + "." + Month + "." + Day;
            }
        }
  
        public List()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        // Добавление элемента в начало списка
        public void AddFirst()
        {
            int data = Int32.Parse(Console.ReadLine());
            Node node = new Node(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        public void AddFirst(int data)
        {

            Node node = new Node(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // Добавление элемента в конец списка
        public void AddTail()
        {
            int data = Int32.Parse(Console.ReadLine());
            Node node = new Node(data);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            count++;
        }
        public void AddTail(int data)
        {
            Node node = new Node(data);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            count++;
        }
        // Удаление элемента 
        public bool Delete()
        {
            Console.WriteLine("введите значение элемента для удаления");
            int data = Convert.ToInt32(Console.ReadLine());
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == data) // поиск элемента путём перебора всех элементов
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        // Поиск элемента 
        public bool Search()
        {
            Console.WriteLine("введите значение элемента для поиска");
            int data = Int32.Parse(Console.ReadLine());
            Node current = head;

            while (current != null)
            {

                if (current.Data.Equals(data))
                {

                    Console.WriteLine($"Искомый элемент: {current.Data}");
                    return true;
                }
                current = current.Next;
                if (current == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такого элемента не существует.");
                    Console.ResetColor();
                }
            }
            return false;
        }
        // Вывод элементов
        public void Writeln()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"значение: {current.Data}");

                current = current.Next;
            }
        }
        public static List operator !(List c1)
        {
            List c2 = new List(); // создание инверсивного цикла
            Node current = c1.head;
            while (current != null)
            {
                c2.AddFirst(current.Data);
                current = current.Next;
            }
            return c2;
        }
        public static List operator +(List c1, List c2)
        {
            List c3 = new List();
            Node current1 = c1.head;
            Node current2 = c2.head;
            while (current1 != null)
            {
                c3.AddTail(current1.Data);
                current1 = current1.Next;
            }

            while (current2 != null)
            {
                c3.AddTail(current2.Data);
                current2 = current2.Next;
            }
            return c3;
        }
        public static bool operator ==(List c1, List c2)
        {
            Node current1 = c1.head;
            Node current2 = c2.head;
            while (current1 != null || current2 != null)
            {
                if (current1.Data != current2.Data)
                {
                    return false;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }
            return true;
        }
        public static bool operator !=(List c1, List c2)
        {
            Node current1 = c1.head;
            Node current2 = c2.head;
            while (current1 != null || current2 != null)
            {
                if (current1.Data == current2.Data)
                {
                    return false;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }
            return true;
        }
        public static List operator <(List c1, List c2)
        {

            while (c2.head != null)
            {
                c1.AddTail(c2.head.Data);
                c2.head = c2.head.Next;
            }
            return c1;
        }
        public static List operator >(List c1, List c2)
        {
            while (c1.head != null)
            {
                c2.AddTail(c1.head.Data);
                c1.head = c1.head.Next;
            }
            return c2;
        }
        static void Main(string[] args)
            {

                List obj1 = new List();
                List obj2 = new List();
                Owner Person = new Owner(4235551,"Zhenya","POIT");
                Console.WriteLine($"данные владельца {Person.ToString()}");
                Date Number = new Date(2019,10,14);
                Console.WriteLine($"Дата создания {Number.ToString()}");


                Console.WriteLine("введите количество элементов для добавления в начало");
                int n1 = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n1; i++)
                {
                    obj1.AddFirst();
                }
                Console.WriteLine("введите количество элементов для добавления в конец");
                int n2 = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n2; i++)
                    obj1.AddTail();

                obj1.Writeln();
                obj1.Delete();
                obj1.Writeln();
                obj1.Search();
                obj1.head.DeleteFun();
                obj1.Writeln();
                Console.WriteLine($"сумма элементов {obj1.head.SumElem()}");
                Console.WriteLine($"разница максимума и минимума {StatisticOperation.Distinction(obj1)}");
                Console.WriteLine($"кол-во элементов {StatisticOperation.CountEl(obj1)}");


            Console.WriteLine("введите количество элементов для добавления в начало");
                int n3 = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n3; i++)
                    obj2.AddFirst();

                Console.WriteLine("введите количество элементов для добавления в конец");
                int n4 = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n4; i++)
                    obj2.AddTail();

                obj2.Writeln();
                obj2.Delete();
                obj2.Writeln();
                obj2.Search();

                Console.WriteLine(obj1 == obj1);
                Console.WriteLine(obj1 == obj2);
                Console.WriteLine(obj2 != obj2);
                Console.WriteLine(obj2 != obj1);
                List obj = obj1 + obj2;
                Console.WriteLine("Вывод объединения списков");
                obj.Writeln();

                List obj3 = !obj;
                Console.WriteLine("Вывод инверсивного списка");
                obj3.Writeln();

                List ObjUnion = obj1 > obj2;
                Console.WriteLine("Вывод вложенного списка");
                ObjUnion.Writeln();
        }
        }
    public static class StatisticOperation
    {
        public static void DeleteFun(this List.Node head)
        {
            Console.WriteLine("введите значение после какого удалить элементы");
            int del = Convert.ToInt32(Console.ReadLine());
            Int32 value = 0;
            List.Node current = head;
            List.Node previous = null;
            while (current != null)
            {
                if (del == 0)
                    break;
                if (del <= value)
                {
                    previous.Next = null;
                }
                previous = current;
                current = current.Next;
                value++;
            }
        }
        public static int SumElem(this List.Node head)
        {
            List.Node current = head;
            Int32 sum = 0;
            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }
            return sum;
        }
        public static int Distinction(List c1)
        {
            List.Node current = c1.head;
            Int32 max = current.Data;
            Int32 min = current.Data;
            while (current != null)
            {
                if (current.Data > max) max = current.Data;
                if (current.Data < min) min = current.Data;
                current = current.Next;
            }
            Int32 Dist = max - min;
            return Dist;
        }
        public static int CountEl(List c1)
        {
            List.Node current = c1.head;
            Int32 count = 0;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

    }
}
