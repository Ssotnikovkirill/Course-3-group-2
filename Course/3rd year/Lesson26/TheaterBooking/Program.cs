using System;
using System.Data.SQLite;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        SQLitePCL.Batteries.Init();

        string connectionString = "Data Source=theater.db;Version=3;";
        
        // Запускаем несколько задач параллельно
        Task task1 = ReserveSeatAsync(connectionString, "A3", "Alice");
        Task task2 = ReserveSeatAsync(connectionString, "A3", "Bob");
        
        await Task.WhenAll(task1, task2);
    }

    static async Task ReserveSeatAsync(string connectionString, string seatNumber, string customerName)
    {
        await Task.Delay(new Random().Next(100, 500)); // Симуляция задержки запроса

        using (var connection = new SQLiteConnection(connectionString))
        {
            await connection.OpenAsync();
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var cmdCheck = new SQLiteCommand($"SELECT IsReserved FROM Seats WHERE SeatNumber = '{seatNumber}'", connection, transaction);
                    var result = await cmdCheck.ExecuteScalarAsync();

                    if (result != null && Convert.ToInt32(result) == 0)
                    {
                        var cmdUpdate = new SQLiteCommand($"UPDATE Seats SET IsReserved = 1 WHERE SeatNumber = '{seatNumber}'", connection, transaction);
                        await cmdUpdate.ExecuteNonQueryAsync();

                        var cmdInsert = new SQLiteCommand($"INSERT INTO Reservations (SeatID, CustomerName) SELECT SeatID, '{customerName}' FROM Seats WHERE SeatNumber = '{seatNumber}'", connection, transaction);
                        await cmdInsert.ExecuteNonQueryAsync();

                        var cmdLog = new SQLiteCommand($"INSERT INTO ReservationAttempts (SeatID, CustomerName, Status) SELECT SeatID, '{customerName}', 'SUCCESS' FROM Seats WHERE SeatNumber = '{seatNumber}'", connection, transaction);
                        await cmdLog.ExecuteNonQueryAsync();

                        transaction.Commit();
                        Console.WriteLine($"[{customerName}] Успешно забронировал место {seatNumber}");
                    }
                    else
                    {
                        var cmdLogFail = new SQLiteCommand($"INSERT INTO ReservationAttempts (SeatID, CustomerName, Status) SELECT SeatID, '{customerName}', 'FAILED' FROM Seats WHERE SeatNumber = '{seatNumber}'", connection, transaction);
                        await cmdLogFail.ExecuteNonQueryAsync();

                        transaction.Rollback();
                        Console.WriteLine($"[{customerName}] Не удалось забронировать место {seatNumber} (уже занято)");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
