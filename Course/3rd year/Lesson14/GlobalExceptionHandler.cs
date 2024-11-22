using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GlobalExceptionHandler.Middlewares
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Логика логирования ошибки
            log.Error(context.Exception);

            context.Result = new ObjectResult(new
            {
                message = "Произошла ошибка. Попробуйте позже.",
                error = context.Exception.Message
            })
            {
                StatusCode = 500 // Код статуса "Внутренняя ошибка сервера"
            };
            context.ExceptionHandled = true; // Установить в true, чтобы предотвратить двойную обработку
        }
    }
}