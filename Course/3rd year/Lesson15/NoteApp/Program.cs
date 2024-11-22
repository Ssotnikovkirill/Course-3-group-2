   using Microsoft.Extensions.DependencyInjection;
   using NoteApp.Interfaces;
   using NoteApp.Services;

   var services = new ServiceCollection();

   //  строкa подключения
   string connectionString = "Data Source=notes.db";
   services.AddSingleton<INoteRepository>(new SQLiteNoteRepository(connectionString));
   // services.AddSingleton<INoteRepository>(new FileNoteRepository("notes.txt")); //  локальное хранение
   services.AddSingleton<ILoggerService, ConsoleLoggerService>();
   // services.AddSingleton<ILoggerService>(new DatabaseLoggerService(connectionString)); //  SQL логирование

   var serviceProvider = services.BuildServiceProvider();

   var noteRepository = serviceProvider.GetService<INoteRepository>();
   var logger = serviceProvider.GetService<ILoggerService>();

   // Пример использования
   logger.Log("Запуск приложения заметок...");
   noteRepository.AddNote("Первая заметка");
   logger.Log("Добавлена первая заметка.");

   var notes = noteRepository.GetAllNotes();
   logger.Log("Заметки:");
   foreach (var note in notes)
   {
       logger.Log(note);
   }

