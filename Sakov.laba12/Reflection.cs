using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.IO;

namespace Sakov.laba12
{
    class Reflection
    {
        public static void task1(string type)
        {
            Type myType = Type.GetType($"Sakov.laba12.{type}", false, true);
            string path = @"C:\\SomeDir2";
            using (FileStream fstream = new FileStream($"{path}\\note.txt", FileMode.OpenOrCreate))
            {
                string text;
                foreach (MemberInfo mi in myType.GetMembers())
                {
                    text = mi.DeclaringType.ToString() + " " + mi.MemberType.ToString() + " " + mi.Name.ToString();
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fstream.Write(array, 0, array.Length);
                    byte[] array1 = System.Text.Encoding.Default.GetBytes("\n");
                    fstream.Write(array1, 0, array1.Length);
                }
            }
            Console.WriteLine("Текст записан в файл");

        }
        public static void task2(string type)
        {
            Type myType = Type.GetType($"Sakov.laba12.{type}", false, true);

            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsPublic)
                    modificator += "public ";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        public static void task3(string type)
        {
            Type myType = Type.GetType($"Sakov.laba12.{type}", false, true);

            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }
        public static void task4(string type)
        {
            Type myType = Type.GetType($"Sakov.laba12.{type}", false, true);

            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void task5(string type)
        {
            Type myType = Type.GetType($"Sakov.laba12.{type}", false, true);

            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                if (method.ReturnType.Name == "Int32")
                {
                    Console.Write($"{method.ReturnType.Name} {method.Name} (");
                }

                for (int i = 0; i < parameters.Length; i++)
                {
                    if (method.ReturnType.Name == "Int32")
                    {
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i + 1 < parameters.Length) Console.Write(", ");
                    }
                }
                if (method.ReturnType.Name == "Int32")
                {
                    Console.WriteLine(")");
                }

            }
        }
        public static void task6(string type, string Meth)
        {
            string textFromFile;
            string path = @"C:\\SomeDir2";
            using (FileStream fstream = new FileStream($"{path}\\note1.txt", FileMode.OpenOrCreate))
            {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    textFromFile = System.Text.Encoding.Default.GetString(array);
                    Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            string numer1= textFromFile.Substring(3);
            string numer2 = textFromFile.Substring(0, textFromFile.Length - 2);
            int num1 = int.Parse(numer1);
            int num2 = int.Parse(numer2);
            Type t = Type.GetType($"Sakov.laba12.{type}", true, true);
            // создаем экземпляр класса Program
            object obj = Activator.CreateInstance(t);

            // получаем метод GetResult
            MethodInfo method = t.GetMethod(Meth);

            // вызываем метод, передаем ему значения для параметров и получаем результат
            object result = method.Invoke(obj, new object[] { num1, num2 });
            Console.WriteLine((result));


        }
    }
}
