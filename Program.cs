using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;

namespace ReadFilesInDir
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Hi there!");
            Thread.Sleep(1000);
            Console.WriteLine(
                "This is a windows utility tool to read all filenames inside current path and write them in an output file named results.txt");
            Thread.Sleep(1000);
            Console.WriteLine(
                "If you want to read only certain file types, please write the file extension. Ex:");
            Thread.Sleep(1000);
            Console.WriteLine("png");
            Thread.Sleep(1000);
            Console.WriteLine("will get the names of only the .png files in the current directory");
            Console.WriteLine("For default(all filetypes in the current dir) just press <Enter>:");
            String ext = Console.ReadLine();
            Thread.Sleep(1000);
            Console.WriteLine(
                "filenames are written in alphabetical order by default. if you want to order by filesize instead type: S . For default just press <Enter>");
            String ordBySize = Console.ReadLine();
            IEnumerable fileEntries;
            if (!String.IsNullOrEmpty(ext))
            {
                ext = "*." + ext;
                if (!String.IsNullOrEmpty(ordBySize))
                {
                    Console.WriteLine("you choose to filter only files with extension: " + ext +
                                      " and write them in fileSize desc order");
                }
                else
                {
                    Console.WriteLine("you choosed to filter only files with extension: " + ext);
                }
            }


            fileEntries = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), ext)
                .OrderByDescending(f => new FileInfo(f).Length);

            using (StreamWriter writer = System.IO.File.CreateText("results.txt"))
            {
                foreach (string filename in fileEntries)
                {
                    if (!filename.EndsWith(".exe"))
                    {
                        writer.WriteLine(filename.Substring(Directory.GetCurrentDirectory().Length + 1));
                        i++;
                    }
                }
            }

            Console.WriteLine("Success, a total of " + i +
                              " filenames were written. Please check results.txt file");
            Console.ReadKey(true);
        }
    }
}