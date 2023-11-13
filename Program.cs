using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
       //Пример направления
        string directoryPath = @"C:\ExampleDirectory";

       
        Dictionary<string, int> fileExtensionsCount = new Dictionary<string, int>();

       
        if (Directory.Exists(directoryPath))
        {
            
            string[] files = Directory.GetFiles(directoryPath);


            foreach (string filePath in files)
            {
                
                FileInfo fileInfo = new FileInfo(filePath);

                
                string fileExtension = fileInfo.Extension;

               
                if (!string.IsNullOrEmpty(fileExtension))
                {
                   
                    if (fileExtensionsCount.ContainsKey(fileExtension))
                    {
                        fileExtensionsCount[fileExtension]++;
                    }
                    else
                    {
                        fileExtensionsCount[fileExtension] = 1;
                    }
                }
            }

            
            Console.WriteLine("{0,-20} {1,-10}", "Расширение файла", "Количество");
            Console.WriteLine(new string('-', 30));

            foreach (var entry in fileExtensionsCount)
            {
                Console.WriteLine("{0,-20} {1,-10}", entry.Key, entry.Value);
            }
        }
        else
        {
            Console.WriteLine("Указанный каталог не существует :((((((((((((((((.");
        }
    }
}
