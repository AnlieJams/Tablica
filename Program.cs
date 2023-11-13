using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Укажите путь к каталогу, который вы хотите проанализировать
        string directoryPath = @"C:\ExampleDirectory";

        // Создаем коллекцию для хранения расширений файлов и их количества
        Dictionary<string, int> fileExtensionsCount = new Dictionary<string, int>();

        // Проверяем, существует ли указанный каталог
        if (Directory.Exists(directoryPath))
        {
            // Получаем все файлы в указанном каталоге
            string[] files = Directory.GetFiles(directoryPath);

            // Проходимся по каждому файлу
            foreach (string filePath in files)
            {
                // Получаем информацию о файле
                FileInfo fileInfo = new FileInfo(filePath);

                // Получаем расширение файла (если есть)
                string fileExtension = fileInfo.Extension;

                // Игнорируем файлы без расширения
                if (!string.IsNullOrEmpty(fileExtension))
                {
                    // Добавляем или обновляем счетчик для данного расширения файла
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

            // Выводим результаты в виде таблицы
            Console.WriteLine("{0,-20} {1,-10}", "Расширение файла", "Количество");
            Console.WriteLine(new string('-', 30));

            foreach (var entry in fileExtensionsCount)
            {
                Console.WriteLine("{0,-20} {1,-10}", entry.Key, entry.Value);
            }
        }
        else
        {
            Console.WriteLine("Указанный каталог не существует.");
        }
    }
}
