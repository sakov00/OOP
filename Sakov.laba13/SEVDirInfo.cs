using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.laba13
{
    class SEVDirInfo
    {
        public static void task4()
        {
            string dirName = "C:\\Program Files\\AMD";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            string[] files = Directory.GetFiles(dirName);
            string[] dirs = Directory.GetDirectories(dirName);
            Console.WriteLine($"Кол-во файлов: {files.Length}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Количество поддиректориев: {dirs.Length}");
            Console.WriteLine($"родительские каталоги: {dirInfo.Parent}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            string text = $"Кол-во файлов: {files.Length}" + "\n " + $"Время создания каталога: {dirInfo.CreationTime}"
                + "\n " + $"Количество поддиректориев: {dirs.Length}" + "\n " + $"родительские каталоги: {dirInfo.Parent}"
                + "\n " + $"Полное название каталога: {dirInfo.FullName}"+ "\n";
            SEVLog.task1(text);
        }
    }
}
