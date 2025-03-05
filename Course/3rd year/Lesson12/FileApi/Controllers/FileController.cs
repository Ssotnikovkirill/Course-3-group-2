using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/file")]
public class FileController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessFile([FromBody] string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return BadRequest("Текст не может быть пустым.");

        try
        {
            await FileProcessor.WriteToFileAsync(content);
            string fileContent = await FileProcessor.ReadFromFileAsync();
            return Ok(fileContent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка обработки файла: {ex.Message}");
        }
    }
}
