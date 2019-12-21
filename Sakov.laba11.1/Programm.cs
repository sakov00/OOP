using Mono.CSharp.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sakov.laba11
{
    class Programm
    {
        static void Main(string[] args)
        {
            task1();
            task2();

        }
        public static void task1()
        {
            string[] Month = { "January", "February", "March", "April","May",
                "June", "July", "August", "September", "October", "November","December" };
            int n = int.Parse(Console.ReadLine());
            var LengthMonth = from t in Month 
                              where (t.Length == n) 
                              orderby t  
                              select t;

            foreach (string s in LengthMonth)
                Console.WriteLine(s);

            Console.WriteLine();
            var SeachTimeYear = from t in Month
                                where (t == "December" || t == "January" || t == "February" ||
                                t == "June" || t == "July" || t == "August")
                                orderby t
                                select t;
            foreach (string s in SeachTimeYear)
                Console.WriteLine(s);

            Console.WriteLine();
            var Sort = from t in Month // определяем каждый объект из teams как t
                       orderby t// упорядочиваем по возрастанию
                       select t; // выбираем объект
            foreach (string s in Sort)
                Console.WriteLine(s);

            Console.WriteLine();
            var ustal = from t in Month // определяем каждый объект из teams как t
                        where (t.Length >= 4 && Sorty(t)) //фильтрация по критерию
                        orderby t  // упорядочиваем по возрастанию
                        select t; // выбираем объект

            foreach (string s in ustal)
                Console.WriteLine(s);
        }
        public static void task2()
        {
            int[][] MaimMas = new int[10][];
            MaimMas[0] = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };
            MaimMas[1] = new int[] { 2, 4, 6, 8, 10, 14, 16, 4 };
            MaimMas[2] = new int[] { 112, 23, 4, 5, 2, 5 };
            MaimMas[3] = new int[] { 1, 2, 5, 4, 5, 6 };
            MaimMas[4] = new int[] { 1, 21, 7, 42, 5, 16, 47, 8 };
            MaimMas[5] = new int[] { 1, 2, 5, 4, 5, 6 };
            MaimMas[6] = new int[] { 1, 2, 5, 4, 5, 6 };
            MaimMas[7] = new int[] { 112, 23, 4, 5, 2, 5 };
            MaimMas[8] = new int[] { 1, 2, 5, 4, 5, 6 };
            MaimMas[9] = new int[] { 1, 2, 5, 4, 5, 6 };


            int count = 1;
            IEnumerable<int[]> Chet = from v in MaimMas//массивы только с четными/нечетными элементами; 
                                      from a in v
                                      where (a % 2 == 0 && count++ == v.Length)
                                      select v;
            Print(Chet);

            int MaxSum = (from v in MaimMas//массив с наибольшей суммой элементов
                          from v1 in MaimMas
                          where (v.Sum() > v1.Sum() && v != v1)
                          select v.Sum()).Max();
            IEnumerable<int[]> MaxSumMas = from v in MaimMas
                                           where (v.Sum() == MaxSum)
                                           select v;
            Print(MaxSumMas);
            int MinMas1 = (from v in MaimMas//минимальный массив
                           from v1 in MaimMas
                           where (v.Length < v1.Length && v != v1)
                           select v.Length).Min();
            IEnumerable<int[]> MinMas2 = from v in MaimMas
                                         where (v.Length == MinMas1)
                                         select v;
            Print(MinMas2);
            int put = int.Parse(Console.ReadLine());//количество массивов, содержащих заданное значение 
            int Search = (from v in MaimMas
                          where (v.Contains(put))
                          select v).Count();
            Print(Search);
            count = 3;

            int EqualMas = (from v in MaimMas//количество равных массивов 
                            where (EqualsMas(v, MaimMas[count]) && v!= MaimMas[count] && v.Sum()== MaimMas[count].Sum())
                            select v).Count();
            Print(EqualMas);

            IEnumerable<int[]> SortMAin = from v in MaimMas//упорядоченный массив массивов по первому элементу 

                                          orderby v[0]
                                          select v;
            Print(SortMAin);

            count = 0;
            IEnumerable<int[]> MySpros = (from v in MaimMas.Skip(2)
                                          where (MaimMas.Any()&& v.Max()>MaimMas.First().Max())
                                          orderby v[0]
                                          select v) ;
            Print(MySpros);
            
            List<Student> stud = new List<Student>()
            {
            new Student("Zhenya",2018,"БГТУ"),
            new Student("Kirill",2017,"БГУ")
            };
            List<Univercity> unich = new List<Univercity>()
            {
            new Univercity("БГТУ",1994),
            new Univercity("БГУ",2001)
            };


            var result = from pl in stud
                         join t in unich on pl.Unik equals t.Name
                         select new { Name = pl.Name, Team = pl.Unik,Years= pl.Years };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Years})");
        }
        public static void Print(IEnumerable<int[]> mas)
        {
            foreach (int[] s in mas)
            {
                foreach (int j in s)
                    Console.Write($"{j} ");

                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Print(int Number)
        {
            Console.WriteLine($"значение:{Number} ");
            Console.WriteLine();
        }
        public static bool Sorty(string t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == 'u')
                {
                    return true;
                }
            }
            return false;
        }
        public static bool EqualsMas(int[] mas1, int[] mas2)
        {
            for (int j = 0; j < mas1.Length; j++)
            {

                if (mas1.Length != mas2.Length && mas1[j] != mas2[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
