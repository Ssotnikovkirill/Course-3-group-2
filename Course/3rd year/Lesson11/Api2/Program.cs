   using Microsoft.AspNetCore.Mvc;
   using System.Collections.Generic;

   namespace Api2.Controllers
   {
       [ApiController]
       [Route("[controller]")]
       public class NewsController : ControllerBase
       {
           [HttpGet]
           public IEnumerable<string> Get()
           {
               return new string[] { "News 1", "News 2", "News 3" };
           }
       }
   }