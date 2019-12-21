using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace Sakov.laba13
{
    class SEVFileManager
    {
        public static void task5()
        {
            CreateDir1();
            CreateFile();
            CopyTo();
            //Delete();
            CreateDir2();
            MoveFile();
            MoveDir();
            Compress("C:\\SomeDir2\\SEVFiles\\note.txt", @"C:\\SomeDir2\\SEVFiles.zip");
            Decompress(@"C:\\SomeDir2\\SEVFiles.zip", @"C:\\SomeDir2\\note_zip.txt");
        }
        public static void CreateDir1()
        {
            string path = @"C:\\SomeDir2";
            string subpath = @"SEVInspect";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }
        public static void CreateDir2()
        {
            string path = @"C:\\SomeDir2";
            string subpath = @"SEVFiles";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }
        public static void CreateFile()
        {
            string path = @"C:\\SomeDir2\\sevdirinfo.txt";
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists)
                System.IO.File.Create("C:\\SomeDir2\\sevdirinfo.txt");
            using (StreamWriter fstream = new StreamWriter($"{path}", false))
            {
                fstream.WriteLine("Hello");
                fstream.WriteLine("And");
                fstream.WriteLine("Welcome");
            }
        }
        public static void CopyTo()
        {
            File.Copy(@"C:\\SomeDir2\\sevdirinfo.txt", @"C:\\SomeDir2\\SEVInspect\\Copy.txt", true);
            }
        public static void Delete()
        {
            string path = @"C:\\SomeDir2\\sevdirinfo.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                // альтернатива с помощью класса File
                // File.Delete(path);
            }
        }
        public static void MoveFile()
        {
            //откуда копируем
            string Dir1 = @"C:\\SomeDir2";
            //куда копируем
            string Dir2 = @"C:\\SomeDir2\\SEVFiles";

                DirectoryInfo dirInfo = new DirectoryInfo(Dir1);
                foreach (FileInfo file in dirInfo.GetFiles("*.txt*"))
                {
                    File.Copy(file.FullName, Dir2 + "\\" + file.Name, true);
                }

        }
        public static void MoveDir()
        {
            string oldPath = @"C:\\SomeDir2\\SEVFiles";
            string newPath = @"C:\\SomeDir2\\SEVInspect1";
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo.MoveTo(newPath);
            }
        }
        public static void Compress(string sourceFile, string compressedFile)
        {
                // поток для чтения исходного файла
                using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
                {
                    // поток для записи сжатого файла
                    using (FileStream targetStream = File.Create(compressedFile))
                    {
                        // поток архивации
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                            Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                                sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                        }
                    }
                }
            Console.WriteLine();

        }
        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
            Console.WriteLine();
        }

    }
}
