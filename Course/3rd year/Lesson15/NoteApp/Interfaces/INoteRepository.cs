   namespace NoteApp.Interfaces
   {
       public interface INoteRepository
       {
           void AddNote(string note);
           IEnumerable<string> GetAllNotes();
       }
   }