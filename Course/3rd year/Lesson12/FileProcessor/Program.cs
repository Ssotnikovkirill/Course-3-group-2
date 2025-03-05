using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        const string filePath = "output.txt";
        Console.WriteLine("Введите текст (для выхода введите 'exit'):");

        while (true)
        {
            string input = Console.ReadLine();
            if (input?.Trim().ToLower() == "exit") break;
            await FileProcessor.WriteToFileAsync(filePath, input);
        }

        await FileProcessor.ReadFromFileAsync(filePath);
    }
}
