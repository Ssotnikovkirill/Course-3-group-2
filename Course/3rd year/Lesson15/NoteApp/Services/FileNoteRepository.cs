   using NoteApp.Interfaces;

   namespace NoteApp.Services
   {
       public class FileNoteRepository : INoteRepository
       {
           private readonly string _filePath;

           public FileNoteRepository(string filePath)
           {
               _filePath = filePath;
           }

           public void AddNote(string note)
           {
               File.AppendAllLines(_filePath, new[] { note });
           }

           public IEnumerable<string> GetAllNotes()
           {
               return File.Exists(_filePath) ? File.ReadAllLines(_filePath) : Enumerable.Empty<string>();
           }
       }
   }