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

    public void AddContact(string name, string phone, string email)
{
    using (var connection = new SQLiteConnection($"Data Source={DatabaseFileName};Version=3;"))
    {
        connection.Open();
        string insertQuery = "INSERT INTO Contacts (Name, Phone, Email) VALUES (@name, @phone, @email)";
        using (var command = new SQLiteCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", email);
            command.ExecuteNonQuery();
        }
    }
}

public void DeleteContact(int id)
{
    using (var connection = new SQLiteConnection($"Data Source={DatabaseFileName};Version=3;"))
    {
        connection.Open();
        string deleteQuery = "DELETE FROM Contacts WHERE Id = @id";
        using (var command = new SQLiteCommand(deleteQuery, connection))
        {
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}

public void SearchContacts(string name)
{
    using (var connection = new SQLiteConnection($"Data Source={DatabaseFileName};Version=3;"))
    {
        connection.Open();
        string searchQuery = "SELECT * FROM Contacts WHERE Name LIKE @name";
        using (var command = new SQLiteCommand(searchQuery, connection))
        {
            command.Parameters.AddWithValue("@name", "%" + name + "%");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Phone: {reader["Phone"]}, Email: {reader["Email"]}");
                }
            }
        }
    }
}
}

