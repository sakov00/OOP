using System;
using System.IO;
using System.Reflection;

namespace Sakov.laba13
{
    class SEVLog
    {
        public static void task1(string text)
        {
            DateTime date1 = DateTime.Now;
            string time= date1.ToString();
            string path = @"C:\\SomeDir2";
            string way = ($"{path}\\SEVlogfile.txt");
            using (StreamWriter fstream = new StreamWriter($"{path}\\SEVlogfile.txt", true))
            {
                    byte[] array0 = System.Text.Encoding.Default.GetBytes(time + "\n");
                    fstream.WriteLine(time);
                    byte[] array1 = System.Text.Encoding.Default.GetBytes(way + "\n");
                    fstream.WriteLine(way);
                    byte[] array2 = System.Text.Encoding.Default.GetBytes(text + "\n");
                    fstream.WriteLine(text);
            }
            Console.WriteLine("Текст записан в файл");

        }
        public static void Cheat()
        {

            string path = @"C:\\SomeDir2";
            using (StreamWriter fstream = new StreamWriter($"{path}\\SEVlogfile.txt", false))
            {
                byte[] array0 = System.Text.Encoding.Default.GetBytes("");
                fstream.WriteLine("");
            }
            Console.WriteLine("файл очищен");

        }
        public static void task6()
        {
            string path = @"C:\\SomeDir2";
            using (FileStream fstream = File.OpenRead($"{path}\\SEVlogfile.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                textFromFile.Substring(0,40);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
    }
}
