using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class FileProcessor
{
    private static readonly SemaphoreSlim _semaphore = new(4, 4);
    private static readonly string _filePath = "output.txt";

    public static async Task WriteToFileAsync(string content)
    {
        await _semaphore.WaitAsync();
        try
        {
            using StreamWriter writer = new(_filePath, append: true, Encoding.UTF8);
            await writer.WriteLineAsync(content);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public static async Task<string> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return "Файл отсутствует.";

        return await File.ReadAllTextAsync(_filePath, Encoding.UTF8);
    }
}
