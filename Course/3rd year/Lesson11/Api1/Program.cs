using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Sunny", "Cloudy", "Rainy" };
        }
    }
}