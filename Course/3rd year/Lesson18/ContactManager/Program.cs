using System;

class Program
{
    static void Main(string[] args)
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        dbHelper.InitializeDatabase();

        while (true)
        {
            Console.WriteLine("\nВыберите действие: \n1. Добавить контакт\n2. Удалить контакт\n3. Найти контакт\n4. Выйти");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите телефон: ");
                    string phone = Console.ReadLine();
                    Console.Write("Введите email (необязательно): ");
                    string email = Console.ReadLine();
                    dbHelper.AddContact(name, phone, email);
                    Console.WriteLine("Контакт добавлен.");
                    break;

                case "2":
                    Console.Write("Введите ID контакта для удаления: ");
                    int idToDelete = int.Parse(Console.ReadLine());
                    dbHelper.DeleteContact(idToDelete);
                    Console.WriteLine("Контакт удален.");
                    break;

                case "3":
                    Console.Write("Введите часть имени для поиска: ");
                    string nameToSearch = Console.ReadLine();
                    dbHelper.SearchContacts(nameToSearch);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}