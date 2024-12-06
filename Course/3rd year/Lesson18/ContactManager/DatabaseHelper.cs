using System;
using System.Data.SQLite;

public class DatabaseHelper
{
    private const string DatabaseFileName = "contacts.db";

    public void InitializeDatabase()
    {
        // Проверяем, существует ли файл базы данных. Если нет - создаем его.
        if (!System.IO.File.Exists(DatabaseFileName))
        {
            SQLiteConnection.CreateFile(DatabaseFileName);
        }

        using (var connection = new SQLiteConnection($"Data Source={DatabaseFileName};Version=3;"))
        {
            connection.Open();

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Contacts (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            Phone TEXT NOT NULL,
                                            Email TEXT
                                          );";

            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}