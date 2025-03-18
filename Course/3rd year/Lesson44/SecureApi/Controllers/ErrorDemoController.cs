using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers
{
    [Route("api/errors")]
    [ApiController]
    public class ErrorDemoController : ControllerBase
    {
        [HttpGet("bad-request")]
        public IActionResult BadRequestError()
        {
            throw new ArgumentNullException("Пример ошибки: Переданы некорректные данные.");
        }

        [HttpGet("unauthorized")]
        [Authorize]
        public IActionResult UnauthorizedError()
        {
            throw new UnauthorizedAccessException("Пример ошибки: Недостаточно прав.");
        }

        [HttpGet("not-found")]
        public IActionResult NotFoundError()
        {
            throw new KeyNotFoundException("Пример ошибки: Данные не найдены.");
        }

        [HttpGet("internal")]
        public IActionResult InternalServerError()
        {
            throw new Exception("Пример ошибки: Внутренняя ошибка сервера.");
        }
    }
}
