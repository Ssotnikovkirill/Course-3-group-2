using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

class FileProcessor
{
    private static readonly object _lock = new();

    public static async Task WriteToFileAsync(string filePath, string content)
    {
        lock (_lock)
        {
            using StreamWriter writer = new(filePath, append: true, Encoding.UTF8);
            writer.WriteLine(content);
        }
    }

    public static async Task ReadFromFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл отсутствует.");
            return;
        }

        string content = await File.ReadAllTextAsync(filePath, Encoding.UTF8);
        Console.WriteLine("Содержимое файла:");
        Console.WriteLine(content);
    }
}
