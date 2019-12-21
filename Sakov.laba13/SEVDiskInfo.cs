using System;
using System.IO;

namespace Sakov.laba13
{
    class SEVDiskInfo
    {
        public static void task2()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string text="";
            foreach (DriveInfo drive in drives)
            {
                text += $"Название: {drive.Name}" + " "+ $"Тип: {drive.DriveType}" + " ";
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    text += $"Объем диска: {drive.TotalSize}" + " " + $"Свободное пространство: {drive.TotalFreeSpace}" + " " + $"Метка: {drive.VolumeLabel}" + "\n";
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
            SEVLog.task1(text);
        }
    }
}
