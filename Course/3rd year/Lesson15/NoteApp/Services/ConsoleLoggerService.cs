   using NoteApp.Interfaces;

   namespace NoteApp.Services
   {
       public class ConsoleLoggerService : ILoggerService
       {
           public void Log(string message)
           {
               Console.WriteLine(message);
           }
       }
   }