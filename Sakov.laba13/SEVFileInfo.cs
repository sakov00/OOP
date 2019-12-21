using System;
using System.IO;
using System.Reflection;

namespace Sakov.laba13
{
    class SEVFileInfo
    {
        public static void task3()
        {
            string path = @"C:\\SomeDir2\\SEVlogfile.txt";
            FileInfo fileInf = new FileInfo(path);
            string text = "";
            if (fileInf.Exists)
            {
                text += $"Путь: {path}" + "\n " + $"Имя файла: {fileInf.Name}" + "\n " + $"Расширение файла: {fileInf.Extension}" + "\n "
                    + $"Размер: {fileInf.Length}" + "\n " + $"Время создания: {fileInf.CreationTime}"+ "\n";
                Console.WriteLine("Путь: {0}", path);
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Расширение файла: {0}", fileInf.Extension);
                Console.WriteLine("Размер: {0}", fileInf.Length);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine();
                SEVLog.task1(text);
            }
            
        }
    }
}
