namespace EssentialCSharp.Chapter15.Listing15_02
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //List1(Directory.GetCurrentDirectory(), "*");
            List1(@"C:\Users\HZWNB147\Desktop", "*.jpg");
        }
        static void List1(string roorDirectory, string searchPattern)
        {
            IEnumerable<string> fileNames = Directory.GetFiles(roorDirectory,searchPattern);
            IEnumerable<FileInfo> fileInfos =
                from fileName in fileNames
                select new FileInfo(fileName);
            foreach (FileInfo fileinfo in fileInfos)
            {
                Console.WriteLine($@".{fileinfo.Name}({fileinfo.LastWriteTime})");
            }
        }
    }
}
