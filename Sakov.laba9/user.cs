using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.laba9
{
    public delegate void Doing(string str);
    public delegate void Action<T>(T obj);
    public delegate void Func<T>(T obj);

    class User
    {
        public event Doing upgrade;
        public event Doing work;
        public string name;
        public int timeDays;
        public string str;
        public User(string Name, int TimeDays,string Str)
        {
            name = Name;
            timeDays = TimeDays;
            str = Str;
        }
        public static void Print(User obj)
        {
            Console.WriteLine($"инфа об объекте {obj.name} {obj.timeDays} {obj.str}");
        }
        public void Print1()
        {
            Console.WriteLine($"инфа об объекте {name} {timeDays} {str}");
            work?.Invoke("вывод сообщения work\n");
        }
        public void Print2()
        {
            Console.WriteLine($"инфа об объекте {name} {timeDays} {str}");
            upgrade?.Invoke("обновление пришло upgrade\n");
        }

        public string AddSymbol(string str)
        {
            if (upgrade!=null)
            {
                Console.WriteLine("введите строку ");
                string input = Console.ReadLine();
                str = str.Insert(str.Length, input);
                upgrade?.Invoke($"вывод сообщения upgrade \n" +
                    $"строка после добавления {str}\n");
            }
            return str;
        }
        public string DelSymbol(string str)
        {
            if (upgrade != null)
            {
                Console.WriteLine("введите число после которой удаляються символы ");
                int input = int.Parse(Console.ReadLine());
                str = str.Remove(input);
                upgrade?.Invoke($"вывод сообщения upgrade \n" +
                    $"строка после добавления {str}\n");
            }
            return str;
        }
        public string DelPrep(string str)
        {
            string str1="";
            if (work != null)
            {

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '.' || str[i] == ';' || str[i] == ':' || str[i] == ',' || str[i]== '-' || str[i] == '!' || str[i] == '?' || str[i] == '(' || str[i] == ')' || str[i]== '"')
                    {

                    }
                    else str1 = str1 + str[i];
                }
                str = str1;
                work?.Invoke($"вывод сообщения upgrade \n" +
                    $"строка после добавления {str}\n");
            }
            return str;
        }
        public static User SymbolUp(User value)
        {
            string str1 = "";
                for (int i = 0; i < value.str.Length; i++)
                str1 += value.str.ToUpper()[i];
                value.str = str1;
            return value;
        }
        public static void Operation(User obj)
        {
            bool f = true;
            while (f)
            {
                Console.WriteLine("1. добавить символ ");
                Console.WriteLine("2. удалить символ ");
                Console.WriteLine("3. удалить знаки препинания");
                Console.WriteLine("4. перевести символы в верхний регистр ");
                Console.WriteLine("5. инфа о подписке и пользователях ");
                Console.WriteLine("0. выход ");

                string put = Console.ReadLine();
                switch (put)
                {
                    case "0":
                        f = false;
                        break;

                    case "1":
                        obj.str = obj.AddSymbol(obj.str);
                        break;

                    case "2":
                        obj.str = obj.DelSymbol(obj.str);
                        break;

                    case "3":
                        obj.str = obj.DelPrep(obj.str);
                        break;

                    case "4":
                        SymbolUp(obj);
                        break;
                    case "5":
                        obj.Print1();
                        obj.Print2();
                        break;
                    default:
                        Console.WriteLine(" не правильное значение");
                        f = false;
                        break;
                }

            }

        }
       

    }
}

