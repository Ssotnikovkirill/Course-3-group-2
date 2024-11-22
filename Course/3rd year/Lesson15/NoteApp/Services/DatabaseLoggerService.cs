   using Microsoft.Data.Sqlite;
   using NoteApp.Interfaces;

   namespace NoteApp.Services
   {
       public class DatabaseLoggerService : ILoggerService
       {
           private readonly string _connectionString;

           public DatabaseLoggerService(string connectionString)
           {
               _connectionString = connectionString;
               using var connection = new SqliteConnection(_connectionString);
               connection.Open();
               var command = connection.CreateCommand();
               command.CommandText = "CREATE TABLE IF NOT EXISTS Logs (Id INTEGER PRIMARY KEY, Message TEXT);";
               command.ExecuteNonQuery();
           }

           public void Log(string message)
           {
               using var connection = new SqliteConnection(_connectionString);
               connection.Open();
               var command = connection.CreateCommand();
               command.CommandText = "INSERT INTO Logs (Message) VALUES (@message);";
               command.Parameters.AddWithValue("@message", message);
               command.ExecuteNonQuery();
           }
       }
   }