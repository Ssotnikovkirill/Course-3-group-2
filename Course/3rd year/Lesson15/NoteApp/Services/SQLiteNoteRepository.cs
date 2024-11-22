   using Microsoft.Data.Sqlite;
   using NoteApp.Interfaces;

   namespace NoteApp.Services
   {
       public class SQLiteNoteRepository : INoteRepository
       {
           private readonly string _connectionString;

           public SQLiteNoteRepository(string connectionString)
           {
               _connectionString = connectionString;
           }

           public void AddNote(string note)
           {
               using var connection = new SqliteConnection(_connectionString);
               connection.Open();
               var command = connection.CreateCommand();
               command.CommandText = "CREATE TABLE IF NOT EXISTS Notes (Id INTEGER PRIMARY KEY, Note TEXT);";
               command.ExecuteNonQuery();

               command.CommandText = "INSERT INTO Notes (Note) VALUES (@note);";
               command.Parameters.AddWithValue("@note", note);
               command.ExecuteNonQuery();
           }

           public IEnumerable<string> GetAllNotes()
           {
               using var connection = new SqliteConnection(_connectionString);
               connection.Open();
               var command = connection.CreateCommand();
               command.CommandText = "SELECT Note FROM Notes;";

               using var reader = command.ExecuteReader();
               while (reader.Read())
               {
                return reader.GetString(0);
               }
           }
       }
   }