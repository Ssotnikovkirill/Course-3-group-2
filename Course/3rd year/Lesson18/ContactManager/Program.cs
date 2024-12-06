using System;

class Program
{
    static void Main(string[] args)
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        dbHelper.InitializeDatabase();
        
        Console.WriteLine("База данных и таблица контактов созданы.");
    }
}