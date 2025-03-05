using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        const string filePath = "output.txt";
        Console.WriteLine("Введите текст (для выхода введите 'exit'):");

        var tasks = new List<Task>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input?.Trim().ToLower() == "exit") break;
            tasks.Add(FileProcessor.WriteToFileAsync(filePath, input));
        }

        await Task.WhenAll(tasks);
        await FileProcessor.ReadFromFileAsync(filePath);
    }
}
