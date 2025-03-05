using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class FileProcessor
{
    private static readonly SemaphoreSlim _semaphore = new(4, 4);

    public static async Task WriteToFileAsync(string filePath, string content)
    {
        await _semaphore.WaitAsync();
        try
        {
            using StreamWriter writer = new(filePath, append: true, Encoding.UTF8);
            await writer.WriteLineAsync(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public static async Task ReadFromFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл отсутствует.");
            return;
        }

        try
        {
            string content = await File.ReadAllTextAsync(filePath, Encoding.UTF8);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
        }
    }
}
