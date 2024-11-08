   using System;
   using System.Net.Http;
   using System.Threading.Tasks;

   namespace MyConsoleApp
   {
       class Program 
       {
           static async Task Main(string[] args)
           {
               HttpClient client = new HttpClient();
               var weatherTask = client.GetStringAsync("http://localhost:5000/weatherforecast");
               var newsTask = client.GetStringAsync("http://localhost:5001/news");

               await Task.WhenAll(weatherTask, newsTask);

               var weather = await weatherTask;
               var news = await newsTask;

               Console.WriteLine("Weather Forecast: " + weather);
               Console.WriteLine("News: " + news);
           }
       }
   }